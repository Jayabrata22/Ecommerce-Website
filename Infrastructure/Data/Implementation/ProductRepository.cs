using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Implementation
{
    public class ProductRepository(EcommerceContext ecommerceContextP) : IProductRepository
    {
        public void AddProduct(Product product)
        {
            ecommerceContextP.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            ecommerceContextP.Products.Remove(product);
        }

        public async Task<IReadOnlyList<string>> GetBrandAsync()
        {
            return await ecommerceContextP.Products.Select(x => x.Brand).Distinct().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await ecommerceContextP.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync( )
        {
            return await ecommerceContextP.Products.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brands, string? types, string? sort)
        {
           var query = ecommerceContextP.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(brands))
            {
                query = query.Where(x=> x.Brand ==  brands);
            }
            if (!string.IsNullOrWhiteSpace(types))
            {
                query = query.Where(x=> x.Type == types);
            }
            query = sort switch
            {
                "priceAsc"=> query.OrderBy(x=>x.Price),
                "priceDesc" => query.OrderByDescending(x=>x.Price),
                "_" => query.OrderBy(x=>x.ProductName),
            };
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<string>> GetTypeAsync()
        {
            return await ecommerceContextP.Products.Select(x => x.Type).Distinct().ToListAsync();
        }

        public bool ProductExists(int id)
        {
            return ecommerceContextP.Products.Any(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await ecommerceContextP.SaveChangesAsync() > 0;
        }

        public void UpdateProduct(Product product)
        {
            ecommerceContextP.Entry(product).State = EntityState.Modified;
        }
    }
}
