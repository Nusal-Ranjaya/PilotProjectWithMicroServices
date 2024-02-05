using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLayer.CustomerRepository
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<InternalCustomer>> GetAllInternalCustomersAsync();
        Task<IEnumerable<ReqResCustomer>> GetAllReqResCustomerAsync();
        Task<ReqResCustomer> GetReqResCustomerAsync(Guid id);
        Task<InternalCustomer> GetInternalCustomerAsync(Guid id);
        Task UpdateCustomerAsync(InternalCustomer customer);
        Task DeleteCustomerAsync(Guid id);   
        Task CreateCustomerAsync(InternalCustomer customer);
        bool InternalCustomerExistsAsync(Guid id);
    }
}
