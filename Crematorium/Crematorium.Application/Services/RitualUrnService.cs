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
    public class RitualUrnService : BaseService<RitualUrn>
    {
       public RitualUrnService(IUnitOfWork unitOfWork) 
       {
            _repository = unitOfWork.RitualUrnRepository;
       }

        public async Task<IEnumerable<User>> FindByName(string name)
        {
            return (IEnumerable<User>)await _repository.ListAsync(u => u.Name == name);
        }
    }
}
