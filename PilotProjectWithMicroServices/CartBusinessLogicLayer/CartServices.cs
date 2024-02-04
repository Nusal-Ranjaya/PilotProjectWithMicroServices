using CartBusinessLogicLayer.ExternalServices;
using CartDataAccessLayer.CartRepository;
using CartDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusinessLogicLayer
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepo _repo;
        private readonly IExternalCustomerServices _externalCustomerServices;
        public CartServices(ICartRepo repo, IExternalCustomerServices externalCustomerServices)
        {
            _repo = repo;
            _externalCustomerServices = externalCustomerServices;
        }
        public async Task<bool> CreateCartAsync(Cart cart)
        {
            var check = await _externalCustomerServices.CustomerExistsAsync(cart.CusId);
            if (check)
            {
                _repo.CreateCartAsync(cart);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            return await _repo.GetAllCartsAsync();
        }

        public Task<Cart> GetCartAsync(int id)
        {
            return _repo.GetCartAsync(id);
        }

        public void RemoveCartAsync(int id)
        {
            _repo.RemoveCartAsync(id);
        }
    }
}
