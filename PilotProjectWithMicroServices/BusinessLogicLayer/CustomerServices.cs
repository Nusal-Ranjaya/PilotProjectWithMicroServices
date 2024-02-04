using CustomerDataLayer.CustomerRepository;
using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLogicLayer
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerServices(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public void CreateCustomerAsync(InternalCustomer customer)
        {
            _customerRepo.CreateCustomerAsync(customer);
        }

        public void DeleteCustomerAsync(int id)
        {
            _customerRepo.DeleteCustomerAsync(id);
        }

        public async Task<IEnumerable<InternalCustomer>> GetAllInternalCustomersAsync()
        {
            return await _customerRepo.GetAllInternalCustomersAsync();
        }

        public async  Task<IEnumerable<ReqResCustomer>> GetAllReqResCustomerAsync()
        {
            return await _customerRepo.GetAllReqResCustomerAsync();
        }

        public async Task<InternalCustomer> GetInternalCustomerAsync(int id)
        {
            return await _customerRepo.GetInternalCustomerAsync(id);
        }

        public async Task<ReqResCustomer> GetReqResCustomerAsync(int id)
        {
            return await _customerRepo.GetReqResCustomerAsync(id);
        }

        public void UpdateCustomerAsync(InternalCustomer customer)
        {
            _customerRepo.UpdateCustomerAsync(customer);
        }
    }
}
