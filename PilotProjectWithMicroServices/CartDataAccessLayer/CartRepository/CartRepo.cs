﻿using CartDataAccessLayer.CartAppDbContext;
using CartDataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccessLayer.CartRepository
{
    public class CartRepo : ICartRepo
    {
        private readonly CartAppDbCon _context;

        public CartRepo() 
        {
            _context = new CartAppDbCon();
        }
        public async void CreateCartAsync(Cart cart)
        {
            _context.carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            var carts =await _context.carts.ToListAsync();
            return carts;
        }

        public async Task<Cart> GetCartAsync(int id)
        {
            return await _context.carts.FirstOrDefaultAsync(m=>m.Id==id);
        }

        public async void RemoveCartAsync(int id)
        {
            var cartToRemove = _context.carts.FirstOrDefault(c => c.Id == id);
            if (cartToRemove != null)
            {
                _context.carts.Remove(cartToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
