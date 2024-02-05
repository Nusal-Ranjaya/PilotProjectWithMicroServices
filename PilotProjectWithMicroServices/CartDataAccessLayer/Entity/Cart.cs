using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccessLayer.Entity
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid? CusId { get; set; }
        public string? Product { get; set; }
        public string? DeliveryAddress { get; set;}
        
    }
}
