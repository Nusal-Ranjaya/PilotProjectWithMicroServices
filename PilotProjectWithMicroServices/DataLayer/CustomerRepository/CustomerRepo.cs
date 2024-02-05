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
        public CustomerRepo(ICustomerMapper cusMapper, CustomerAppDbCon context)
        {
           // _context = new CustomerAppDbCon();
           _context=context;
            _cusMapper  = cusMapper;
            _mapper = _cusMapper.InitializeMapper();
        }
        public async Task CreateCustomerAsync(InternalCustomer customer)
        {
            await _context.internalCustomers.AddAsync(customer);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteCustomerAsync(Guid id)
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

        public async Task<InternalCustomer> GetInternalCustomerAsync(Guid id)
        {
            return await _context.internalCustomers.FirstOrDefaultAsync(m => m.Id == id);
            
        }

        public async Task<ReqResCustomer> GetReqResCustomerAsync(Guid id)
        {
            var internalCustomer = await _context.internalCustomers.FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<ReqResCustomer>(internalCustomer);
        }

        public bool InternalCustomerExistsAsync(Guid id)
        {
            return _context.internalCustomers.Any(m => m.Id == id);
        }

        public async Task UpdateCustomerAsync(InternalCustomer customer)
        {
            var existingCustomer = await _context.internalCustomers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                // Update the properties of existingCustomer with data properties
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Password= customer.Password;
                existingCustomer.Address = customer.Address;

                await _context.SaveChangesAsync();
            }
        }
    }
}
