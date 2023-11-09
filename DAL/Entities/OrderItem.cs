namespace DAL.Entities
{
    public class OrderItem
    {
        /// <summary>
        /// Id элемента заказа
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Id заказа
        /// </summary>
        public int OrderId { get; init; }

        /// <summary>
        /// Имя элемента заказа
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Количество элементов
        /// </summary>
        public decimal Quantity { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; init; }
    }
}
