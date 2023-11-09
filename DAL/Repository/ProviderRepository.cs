using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repository
{
    public class ProviderRepository : IRepository<Provider>
    {
        private readonly SolfOrbContext _context;

        public ProviderRepository(SolfOrbContext context)
        {
            _context = context;
        }

        public void Create(Provider item)
        {
           _context.Providers.Add(item);
        }

        public void Delete(Provider item)
        {
            if (item != null)
            {
                _context.Providers.Remove(item);
            }
        }

        public IEnumerable<Provider> Find(Func<Provider, bool> predicate)
        {
            IQueryable<Provider> user = _context.Providers;
            return user.Where(predicate);
        }

        public Provider Get(int id)
        {
            return _context.Providers.First(p => p.Id == id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers.ToList();
        }

        public void Update(Provider item)
        {
            if (item != null)
            {
                _context.Update(item);
            }
        }
    }
}
