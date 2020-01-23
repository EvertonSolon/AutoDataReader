using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories.Contracts.Base;

namespace WebApi.Repositories.Contracts
{
    public interface IUserRepository : ICrudBaseRepository<User>
    {
    }
}
