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
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        public UserService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.UserRepository;
        }

        public async Task<User> AddAsync(User item)
        {
            await _repository.AddAsync(item);
            return item;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (item != default)
            {
                await _repository.DeleteAsync(item);
            }

            return item;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> IsValided(string name, string numPassport)
        {
            var item = _repository.FirstOrDefaultAsync(u => u.Name == name && u.NumPassport == numPassport).Result;
            if (item  == default)
            {
                return false;
            }

            return true;
        }

        public async Task<User> UpdateAsync(User item)
        {
            await _repository.UpdateAsync(item);
            return item;
        }
    }
}
