using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly EcommerceContext ecommerceContext;

        public ProductController(EcommerceContext ecommerceContext)
        {
            this.ecommerceContext = ecommerceContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
           return await ecommerceContext.Products.ToListAsync();
            
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> getproductByid(int id)
        {
            var product = ecommerceContext.Products.FindAsync(id);
            if(product != null)
            {
                return await product;
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Createproduct(Product product)
        {
            ecommerceContext.Products.AddAsync(product);

            await ecommerceContext.SaveChangesAsync();  
            return product;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> updateProduct(int id, Product product)
        {
            if(product.Id != id || !ProductExists(id))
                return BadRequest("Can not Update Product");

            ecommerceContext.Entry(product).State = EntityState.Modified;
            await ecommerceContext.SaveChangesAsync();
            return Ok();
        }

        private bool ProductExists(int id)
        {
           return ecommerceContext.Products.Any(p => p.Id == id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var findproduct = await ecommerceContext.Products.FindAsync(id);
            if(findproduct == null) return NotFound();

            ecommerceContext.Remove(findproduct);
            await ecommerceContext.SaveChangesAsync();
            return Ok();

        }
    }
}
