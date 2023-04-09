using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Persistense.Repository
{
    public class FakeUsersRepository : IRepository<User>
    {
        private List<User> _users = new List<User>();

        public FakeUsersRepository()
        {
            _users.Add(new User()
            {
                Name = "Admin",
                Surname = "Adminov",
                NumPassport = "Admin123",
                UserRole = Role.Admin,
                MailAdress = "Admin@mail.ru"
            });
        }

        public Task AddAsync(User entity, CancellationToken cancellationToken = default)
        {
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            _users.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<User?> FirstOrDefaultAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _users.FirstOrDefault(filter.Compile()));
        }

        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<User, object>>[]? includesProperties)
        {
            return Task.Run(() => _users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<IReadOnlyList<User>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _users);
        }

        public Task<IReadOnlyList<User>> ListAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<User, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
