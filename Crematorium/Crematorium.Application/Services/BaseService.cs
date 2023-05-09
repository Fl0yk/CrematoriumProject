using Crematorium.Application.Abstractions;
using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Application.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected IRepository<T> _repository;

        public async Task<T> AddAsync(T item)
        {
            await _repository.AddAsync(item);
            return item;
        }

        public async Task<T?> DeleteAsync(int id)
        {
            var item = _repository.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (item != default)
            {
                await _repository.DeleteAsync(item);
            }

            return item;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> UpdateAsync(T item)
        {
            await _repository.UpdateAsync(item);
            return item;
        }
    }
}
