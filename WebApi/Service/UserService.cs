using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories.Contracts;
using WebApi.Service.Contracts;

namespace WebApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Create(User user)
        {
            user.CreatedDate = DateTime.Now;
            _repository.Create(user);
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(User user)
        {
            var result = _repository.Get(user);
            return result;
        }

        public ICollection<User> GetAll()
        {
            var results = _repository.GetAll();

            return results;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
