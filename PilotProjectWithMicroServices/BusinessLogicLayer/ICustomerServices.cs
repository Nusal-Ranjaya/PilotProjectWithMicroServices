using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLogicLayer
{
    public interface ICustomerServices
    {
        Task<IEnumerable<InternalCustomer>> GetAllInternalCustomersAsync();
        Task<IEnumerable<ReqResCustomer>> GetAllReqResCustomerAsync();
        Task<ReqResCustomer> GetReqResCustomerAsync(Guid id);
        Task<InternalCustomer> GetInternalCustomerAsync(Guid id);
        void UpdateCustomerAsync(Guid id,PostCustomer postCustomer);
        void DeleteCustomerAsync(Guid id);
        void CreateCustomerAsync(PostCustomer postCustomer);
    }
}
