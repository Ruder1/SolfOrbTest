using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;

namespace BuisnessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;

        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            var ordersDal = _database.Orders.GetAll();
            var ordersDTO = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(ordersDal);
            return ordersDTO;
        }

        public void CreateOrder(OrderDTO order)
        {
            var orderDAL = _mapper.Map<OrderDTO, Order>(order);
            _database.Orders.Create(orderDAL);
            _database.Save();
        }

        public void DeleteOrder(int number)
        {
            var order = _database.Orders.Get(number);
            if (order != null)
            {
                _database.Orders.Delete(order);
                _database.Save();
            }
        }

        public void UpdateOrder(OrderDTO order)
        {
            var orderDAL = _mapper.Map<OrderDTO, Order>(order);

            
            var removedItems = _database.Items
                .GetAll()
                .Where(d => d.OrderId == orderDAL.Id).ToList();

            foreach (var item in removedItems)
            {
                _database.Items.Delete(item);
            }
            _database.Orders.Update(orderDAL);
            _database.Save();

        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public bool CheckOrderAndProvider(OrderDTO item)
        {

            var orders = _database.Orders.GetAll().Where(d=>d.ProviderId == item.Provider.Id && d.Number == item.Number);
            if (orders.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
