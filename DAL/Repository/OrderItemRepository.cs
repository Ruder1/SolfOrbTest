using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class OrderItemRepository : IRepository<OrderItem>
    {

        private readonly SolfOrbContext _context;

        public OrderItemRepository(SolfOrbContext context)
        {
            _context = context;
        }

        public void Create(OrderItem item)
        {
            _context.OrderItems.Add(item);
        }

        public void Delete(OrderItem item)
        {
            if (item != null)
                _context.OrderItems.Remove(item);
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            IQueryable<OrderItem> user = _context.OrderItems;
            return user.Where(predicate);
        }

        public OrderItem Get(int id)
        {
            return _context.OrderItems.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public void Update(OrderItem item)
        {
            if (item !=null)
            {
                _context.OrderItems.Update(item);
            }
            
        }
    }
}
