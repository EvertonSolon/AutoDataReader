using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Context
{
    public class WebApiContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }
    }
}
