using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductRepository productRepository,IgenericRepository<Product> igeneric) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct(string? brands, string? types, string? sort)
        {
            return Ok(await productRepository.GetProductsAsync(brands, types, sort));

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> getproductByid(int id)
        {
            var product = igeneric.GetByIdAsync(id);
            if (product != null)
            {
                return await product;
            }
            return BadRequest();
        }
        [HttpGet("brands")]
        public async  Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            return Ok( await productRepository.GetBrandAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            return Ok(await productRepository.GetTypeAsync());
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Createproduct(Product product)
        {
            igeneric.Add(product);

            if (await igeneric.SaveAllAsync()) 
            { return CreatedAtAction("getproductByid", new { id = product.Id }, product); }
            
            return BadRequest("Problem Creating product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> updateProduct(int id, Product product)
        {
            if (product.Id != id || !ProductExists(id))
                return BadRequest("Can not Update Product");

            igeneric.Update(product);
            if (await igeneric.SaveAllAsync())
            { return Ok(); }

            return BadRequest("Problem Creating product");
        }

        private bool ProductExists(int id)
        {
            return igeneric.Exists(id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var findproduct = await igeneric.GetByIdAsync(id);
            if (findproduct == null) return NotFound();

            igeneric.Delete(findproduct);
            if (await igeneric.SaveAllAsync())
            { return Ok(); }

            return BadRequest("Problem Creating product");

        }
    }
}
