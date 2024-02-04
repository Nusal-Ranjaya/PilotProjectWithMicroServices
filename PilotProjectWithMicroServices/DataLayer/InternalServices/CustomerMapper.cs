using AutoMapper;
using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLayer.InternalServices
{
    public class CustomerMapper : ICustomerMapper
    {
        private MapperConfiguration mapperConfig;

        public IMapper InitializeMapper()
        {
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InternalCustomer, ReqResCustomer>();
            });
            var _mapper = mapperConfig.CreateMapper();
            return _mapper;
        }
    }
}
