namespace SolforbUI.Models
{
    public class ProviderViewModel
    {
        /// <summary>
        /// Id поставщика
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Имя поставщика
        /// </summary>
        public string Name { get; init; }

        public List<OrderViewModel> Order { get; init; }
    }
}
