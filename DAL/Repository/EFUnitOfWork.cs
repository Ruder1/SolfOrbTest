using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SolfOrbContext _dbContext;
        private OrderRepository _orderRepository;
        private OrderItemRepository _orderItemRepository;
        private ProviderRepository _providerRepository;

        public EFUnitOfWork(DbContextOptions<SolfOrbContext> connectionString)
        {
            _dbContext = new SolfOrbContext(connectionString);
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_dbContext);
                }
                return _orderRepository;
            }
        }

        public IRepository<OrderItem> Items
        {
            get
            {
                if (_orderItemRepository == null)
                {
                    _orderItemRepository = new OrderItemRepository(_dbContext);
                }
                return _orderItemRepository;
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                if (_providerRepository == null)
                {
                    _providerRepository = new ProviderRepository(_dbContext);
                }
                return _providerRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
