namespace BuisnessLogicLayer.DTO
{
    public class OrderDTO
    {
        /// <summary>
        /// Id Заказа
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public string Number { get; init; }

        /// <summary>
        /// Время когда был сделан заказ
        /// </summary>
        public DateOnly Date { get; init; }

        /// <summary>
        /// Id поставщика элемента заказа
        /// </summary>
        public int ProviderId { get; init; }

        public ProviderDTO Provider { get; init; }

        public List<OrderItemDTO> OrderItem { get; init; }
    }
}
