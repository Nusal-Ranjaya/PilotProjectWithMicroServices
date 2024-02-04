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
        Task<ReqResCustomer> GetReqResCustomerAsync(int id);
        Task<InternalCustomer> GetInternalCustomerAsync(int id);
        void UpdateCustomerAsync(InternalCustomer customer);
        void DeleteCustomerAsync(int id);
        void CreateCustomerAsync(InternalCustomer customer);
    }
}
