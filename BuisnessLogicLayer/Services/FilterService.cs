using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class FilterService : IFilterService
    {

        private readonly IUnitOfWork _database;

        private readonly IMapper _mapper;

        public FilterService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public List<OrderDTO> GetFilteredElements(DataToFilterDTO elements)
        {
            var orders = _database.Orders.GetAll().ToList();

            var temp = new List<Order>();


            if (elements.Orders.Count > 0)
            {
                foreach (var item in elements.Orders)
                {
                    temp.AddRange(orders.Where(x => x.Number == item));
                }
                orders.Clear();
                orders.AddRange(temp);
                temp.Clear();
            }


            if (elements.Providers.Count > 0)
            {
                foreach (var item in elements.Providers)
                {
                    temp.AddRange(orders.Where(x => x.Provider.Name == item).ToList());
                }
                orders.Clear();
                orders.AddRange(temp);
                temp.Clear();
            }

            if (elements.Items.Count > 0)
            {
                foreach (var item in elements.Items)
                {
                    temp.AddRange(orders.Where(x => x.OrderItem.Where(d => d.Name == item).Any()));
                }

                orders.Clear();
                orders.AddRange(temp);
                temp.Clear();
            }

            if (elements.Units.Count > 0)
            {
                foreach (var item in elements.Units)
                {
                    temp.AddRange(orders.Where(x => x.OrderItem.Where(d => d.Unit == item).Any()));
                }

                orders.Clear();
                orders.AddRange(temp);
                temp.Clear();
            }

            temp.AddRange( orders.Where(x => elements.PreviousDate <= x.Date && x.Date <= elements.CurrentDate));

            orders.Clear();
            orders.AddRange(temp);
            temp.Clear();

            var  result = _mapper.Map<List<Order>,List<OrderDTO>>(orders);

            return result;
        }

        public UniqueElementsDTO GetUniqueElements()
        {
            var orders = _database.Orders.GetAll().DistinctBy(d => d.Number).Select(x=>x.Number);
            var providers = _database.Providers.GetAll().DistinctBy(d => d.Name).Select(x=>x.Name);
            var items = _database.Items.GetAll().DistinctBy(d => d.Name).Select(x=>x.Name);
            var units = _database.Items.GetAll().DistinctBy(x => x.Unit).Select(d=>d.Unit);

            var result = new UniqueElementsDTO()
            {
                Items = items.ToList(),
                Providers = providers.ToList(),
                Orders = orders.ToList(),
                Units = units.ToList(),
            };
            return result;
        }
    }
}
