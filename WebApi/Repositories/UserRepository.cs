using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Contracts;

namespace WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebApiContext _context;

        public UserRepository(WebApiContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            //_context.User.Add(user);
            //_context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
