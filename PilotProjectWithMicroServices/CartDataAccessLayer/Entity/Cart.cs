using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccessLayer.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public int? CusId { get; set; }
        public string? product { get; set; }
        public string? DeliveryAddress { get; set;}
        
    }
}
