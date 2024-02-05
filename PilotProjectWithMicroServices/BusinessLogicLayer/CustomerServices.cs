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
        public void CreateCustomerAsync(PostCustomer postCustomer)
        {
            var customer = new InternalCustomer()
            {
                Id = Guid.NewGuid(),
                Name = postCustomer.Name,
                Password = postCustomer.Password,
                Email = postCustomer.Email,
                Address = postCustomer.Address
            };
            _customerRepo.CreateCustomerAsync(customer);
        }

        public void DeleteCustomerAsync(Guid id)
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

        public async Task<InternalCustomer> GetInternalCustomerAsync(Guid id)
        {
            return await _customerRepo.GetInternalCustomerAsync(id);
        }

        public async Task<ReqResCustomer> GetReqResCustomerAsync(Guid id)
        {
            return await _customerRepo.GetReqResCustomerAsync(id);
        }

        public void UpdateCustomerAsync(Guid id,PostCustomer postCustomer)
        {
            var customer = new InternalCustomer()
            {
                Id = id,
                Name = postCustomer.Name,
                Password = postCustomer.Password,
                Email = postCustomer.Email,
                Address = postCustomer.Address
            };
            _customerRepo.UpdateCustomerAsync(customer);
        }
    }
}
