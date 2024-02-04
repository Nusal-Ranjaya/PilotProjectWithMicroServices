using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartDataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace CartDataAccessLayer.CartAppDbContext
{
    public class CartAppDbCon :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=PilotProjectMicroServicesCartDb;Username=postgres;Password=root;");
        }
        public DbSet<Cart> carts { get; set; }
    }
}
