using BuisnessLogicLayer.DTO;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IOrderItemsService
    {
        public IEnumerable<OrderItemDTO> GetItems();
    }
}
