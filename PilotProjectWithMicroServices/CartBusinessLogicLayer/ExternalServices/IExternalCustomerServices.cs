using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusinessLogicLayer.ExternalServices
{
    public interface IExternalCustomerServices
    {
        Task<bool> CustomerExistsAsync(Guid? id);
    }
}
