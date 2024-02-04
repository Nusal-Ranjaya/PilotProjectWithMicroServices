using CustomerDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDataLayer.CustomerAppDBContext;
using CustomerDataLayer.InternalServices;
using Microsoft.EntityFrameworkCore;

namespace CustomerDataLayer.CustomerRepository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerAppDbCon _context;
        private readonly ICustomerMapper _cusMapper;
        private readonly AutoMapper.IMapper _mapper;
        public CustomerRepo(ICustomerMapper cusMapper)
        {
            _context = new CustomerAppDbCon();
            _cusMapper  = cusMapper;
            _mapper = _cusMapper.InitializeMapper();
        }
        public async void CreateCustomerAsync(InternalCustomer customer)
        {
            _context.internalCustomers.Add(customer);
            await _context.SaveChangesAsync();  
        }

        public async void DeleteCustomerAsync(int id)
        {
            var customerToRemove = _context.internalCustomers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                _context.internalCustomers.Remove(customerToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InternalCustomer>> GetAllInternalCustomersAsync()
        {
            return await _context.internalCustomers.ToListAsync();
        }

        public async Task<IEnumerable<ReqResCustomer>> GetAllReqResCustomerAsync()
        {
            var internalCustomers = await _context.internalCustomers.ToListAsync();
            return _mapper.Map<IEnumerable<ReqResCustomer>>(internalCustomers);
        }

        public async Task<InternalCustomer> GetInternalCustomerAsync(int id)
        {
            return await _context.internalCustomers.FirstOrDefaultAsync(m => m.Id == id);
            
        }

        public async Task<ReqResCustomer> GetReqResCustomerAsync(int id)
        {
            var internalCustomer = await _context.internalCustomers.FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<ReqResCustomer>(internalCustomer);
        }

        public bool InternalCustomerExistsAsync(int id)
        {
            return _context.internalCustomers.Any(m => m.Id == id);
        }

        public async void UpdateCustomerAsync(InternalCustomer customer)
        {
            var existingCustomer = await _context.internalCustomers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                // Update the properties of existingCustomer with data properties
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;

                await _context.SaveChangesAsync();
            }
        }
    }
}
