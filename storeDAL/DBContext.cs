using Microsoft.EntityFrameworkCore;
using storeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeDAL
{
    public class DBContext : DbContext
    {
     
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Hero> Heros { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LOG> Logs { get; set; }


    }
}
