using Crematorium.Application.Abstractions;
using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.UserRepository;
            //_repository.AddAsync(new User() { Id = 1, Name = "Admin", MailAdress = "admin@mail.ru", NumPassport = "Admin123", Surname = "Adminov", UserRole = Role.Admin });
        }

        /// <summary>
        /// Проверяет наличие пользователя по имени и номеру паспорта. Возвращает true, если пользователь существует
        /// </summary>
        public Task<bool> IsValided(string name, string numPassport)
        {
            var item = _repository.FirstOrDefaultAsync(u => u.Name == name && u.NumPassport == numPassport).Result;
            if (item  == default)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        } 

        public async Task<IEnumerable<User>> FindByName(string name)
        {
            return await _repository.ListAsync(u => u.Name == name);
        }
    }
}
