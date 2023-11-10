using AutoMapper;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

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
    }
}
