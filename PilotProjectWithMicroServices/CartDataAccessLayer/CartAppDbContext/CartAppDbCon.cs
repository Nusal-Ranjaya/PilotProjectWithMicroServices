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
        public CartAppDbCon(DbContextOptions<CartAppDbCon> options) : base(options) { }
        public DbSet<Cart> carts { get; set; }
    }
}
