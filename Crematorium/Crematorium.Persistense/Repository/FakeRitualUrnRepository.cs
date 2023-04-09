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
    public class FakeRitualUrnRepository : IRepository<RitualUrn>
    {
        private List<RitualUrn> _ritualUrns;

        public FakeRitualUrnRepository()
        {
            _ritualUrns = new List<RitualUrn>();
            throw new Exception("Создай урны!");
        }
        public Task AddAsync(RitualUrn entity, CancellationToken cancellationToken = default)
        {
            _ritualUrns.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(RitualUrn entity, CancellationToken cancellationToken = default)
        {
            if(_ritualUrns.Contains(entity))
                    _ritualUrns.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<RitualUrn> FirstOrDefaultAsync(Expression<Func<RitualUrn, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _ritualUrns.FirstOrDefault(filter.Compile()));
        }

        public async Task<RitualUrn> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<RitualUrn, object>>[]? includesProperties)
        {
            return await Task.Run(() => _ritualUrns.FirstOrDefault(u => u.Id == id));
        }

        public async Task<IReadOnlyList<RitualUrn>> ListAllAsync(CancellationToken cancellationToken = default)
        { 
            return await Task.Run(() => _ritualUrns);
        }

        public Task<IReadOnlyList<RitualUrn>> ListAsync(Expression<Func<RitualUrn, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<RitualUrn, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RitualUrn entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
