using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.Application.Services
{
    public class HallService : HelpersService<Hall>
    {
        public HallService(IUnitOfWork unitOfWork) {
            _repository = unitOfWork.HallRepository;
        }
    }
}
