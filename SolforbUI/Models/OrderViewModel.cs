namespace SolforbUI.Models
{
    public class OrderViewModel
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
        public DateTime Date { get; init; }

        /// <summary>
        /// Id поставщика элемента заказа
        /// </summary>
        public int ProviderId { get; init; }

        public List<OrderItemViewModel> OrderItem { get; init; }  
    }
}
