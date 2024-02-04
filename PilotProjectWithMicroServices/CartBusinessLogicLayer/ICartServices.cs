using CartDataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBusinessLogicLayer
{
    public interface ICartServices
    {
        Task<IEnumerable<Cart>> GetAllCartsAsync();

        Task<Cart> GetCartAsync(int id);

        Task<bool> CreateCartAsync(Cart cart);
        void RemoveCartAsync(int id);
    }
}
