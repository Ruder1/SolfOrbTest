using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий заказов
        /// </summary>
        public IRepository<Order> Orders { get; }

        /// <summary>
        /// Репозиторий элементов заказа
        /// </summary>
        public IRepository<OrderItem> Items { get; }

        /// <summary>
        /// Репозиторий поставщиков
        /// </summary>
        public IRepository<Provider> Providers { get; }

        /// <summary>
        /// Метод сохранения изменений
        /// </summary>
        public void Save();
    }
}
