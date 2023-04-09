using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Persistense.Repository
{
    public class FakeOrderRepository : IRepository<Order>
    {
        private List<Order> _orders = new List<Order>();

        public FakeOrderRepository()
        {
            _orders = new List<Order>();
            throw new Exception("Добавь заказы!");
        }

        public Task AddAsync(Order entity, CancellationToken cancellationToken = default)
        {
            _orders.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Order entity, CancellationToken cancellationToken = default)
        {
            _orders.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _orders.FirstOrDefault(filter.Compile()));
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Order, object>>[]? includesProperties)
        {
            return await Task.Run(() => _orders.FirstOrDefault(u => u.Id == id));
        }

        public async Task<IReadOnlyList<Order>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _orders);
        }

        public Task<IReadOnlyList<Order>> ListAsync(Expression<Func<Order, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Order, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
