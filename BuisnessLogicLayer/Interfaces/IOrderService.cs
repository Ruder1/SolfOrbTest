using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderDTO> GetOrders();
    }
}
