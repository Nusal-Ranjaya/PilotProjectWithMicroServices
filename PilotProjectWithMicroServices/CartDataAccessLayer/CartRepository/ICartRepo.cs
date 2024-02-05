using CartDataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccessLayer.CartRepository
{
    public interface ICartRepo
    {
        Task<IEnumerable<Cart>> GetAllCartsAsync();
        
        Task<Cart> GetCartAsync(Guid id);
      
        void CreateCartAsync(PostCart postCart);

        void RemoveCartAsync(Guid id);
    }
}
