using AutoMapper;
using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLayer.InternalServices
{
    public interface ICustomerMapper
    {
        public IMapper InitializeMapper();
    }
}
