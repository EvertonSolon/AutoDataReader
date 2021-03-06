﻿using System;
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
            _context.Users.Add(user);
            _context.SaveChanges();
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
            var result = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password); //FirstOrDefault(x => x.Email == email && x.Senha == senha);

            return user;
        }

        public ICollection<User> GetAll()
        {
            var entities = _context.Users.ToList();

            return entities;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
