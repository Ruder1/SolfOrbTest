using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BuisnessLogicLayer.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IUnitOfWork _database;

        private readonly IMapper _mapper;

        public OrderItemsService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public IEnumerable<OrderItemDTO> GetItems()
        {
            var itemsDal = _database.Items.GetAll();
            var itemDTO = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDTO>>(itemsDal);
            return itemDTO;
        }
    }
}
