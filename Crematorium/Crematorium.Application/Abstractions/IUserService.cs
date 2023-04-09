using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Application.Abstractions
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> IsValided(string name, string numPassport);
    }
}
