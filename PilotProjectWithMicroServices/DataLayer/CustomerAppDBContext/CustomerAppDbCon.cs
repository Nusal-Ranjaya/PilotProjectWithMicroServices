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

        public CustomerAppDbCon(DbContextOptions<CustomerAppDbCon> options) : base(options) { }

        public DbSet<InternalCustomer> internalCustomers { get; set; }
    }
}
