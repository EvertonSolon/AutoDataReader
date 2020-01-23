using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Service.Contracts.Base;

namespace WebApi.Service.Contracts
{
    public interface IUserService : ICrudBaseService<User>
    {
        User Get(User user);
    }
}
