using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.DAL
{
    public class FlowerContext : DbContext
    {
        public FlowerContext() : base("name=FlowerShop")
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
    }
}