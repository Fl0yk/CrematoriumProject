using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Application.Abstractions
{
    public interface IBaseService<T> where T : Base
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T?> DeleteAsync(int id);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
    }
}
