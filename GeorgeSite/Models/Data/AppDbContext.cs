using GeorgeSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> Email { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        DbContextOptions<AppDbContext> options;
        public AppDbContext(DbContextOptions<AppDbContext> _options) : base(_options)
        {
            options = _options;
            
        }


    }
}
