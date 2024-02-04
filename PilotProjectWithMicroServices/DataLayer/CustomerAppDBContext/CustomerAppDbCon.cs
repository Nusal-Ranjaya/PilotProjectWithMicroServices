using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerDataLayer.CustomerAppDBContext
{
    public class CustomerAppDbCon : DbContext
    {

        //public CustomerAppDbCon(DbContextOptions<CustomerAppDbCon> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=PilotProjectMicroServicesCustomerDb;Username=postgres;Password=root;");
        }
        public DbSet<InternalCustomer> internalCustomers { get; set; }
    }
}
