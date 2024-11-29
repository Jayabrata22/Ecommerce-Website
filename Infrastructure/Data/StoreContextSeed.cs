using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(EcommerceContext ecommerceContextseed)
        {
            if(!ecommerceContextseed.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/Seed Data/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products == null) return;

                ecommerceContextseed.Products.AddRange(products);

                await ecommerceContextseed.SaveChangesAsync();
            }
        }
    }
}
