using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderDTO> GetOrders();

        public void CreateOrder(OrderDTO order);

        public void UpdateOrder(OrderDTO order);

        public void DeleteOrder(int number);

        public bool CheckOrderAndProvider(OrderDTO item);
    }
}
