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
    public class FakeHallRepository : IRepository<Hall>
    {
        private List<Hall> _halls;

        public FakeHallRepository()
        {
            _halls = new List<Hall>();
            throw new Exception("Создай залы!");
        }

        public Task AddAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            _halls.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            if (_halls.Contains(entity))
                _halls.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<Hall?> FirstOrDefaultAsync(Expression<Func<Hall, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _halls.FirstOrDefault(filter.Compile()));
        }

        public async Task<Hall?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Hall, object>>[]? includesProperties)
        {
            return await Task.Run(() => _halls.FirstOrDefault(u => u.Id == id));
        }

        public async Task<IReadOnlyList<Hall>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _halls);
        }

        public Task<IReadOnlyList<Hall>> ListAsync(Expression<Func<Hall, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Hall, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
