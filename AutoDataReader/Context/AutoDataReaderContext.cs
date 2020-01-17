using AutoDataReader.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Context
{
    public class AutoDataReaderContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public AutoDataReaderContext(DbContextOptions<AutoDataReaderContext> options) : base(options)
        {
            
        }
        
    }
}
