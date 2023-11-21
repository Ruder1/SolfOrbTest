using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {

        private readonly SolfOrbContext _context;

        public OrderRepository(SolfOrbContext context)
        {
            _context = context;
        }

        public void Create(Order item)
        {
            var provider = _context.Providers.FirstOrDefault(p => p.Id == item.ProviderId);
            _context.Providers.Attach(provider);
            item.Provider = provider;
            _context.Orders.Add(item);
        }

        public void Delete(Order item)
        {
            if (item != null)
                _context.Orders.Remove(item);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            IQueryable<Order> user = _context.Orders;
            return user.Where(predicate);
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context
                .Orders
                .Include(p=>p.Provider)
                .Include(o=>o.OrderItem)                 
                .ToList();
        }

        public void Update(Order order)
        {
            if (order != null)
            {
                _context.Orders.Update(order);
            }
        }
    }
}
