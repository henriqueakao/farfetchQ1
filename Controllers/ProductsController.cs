using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farfetchQ1.Data;
using farfetchQ1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace farfetchQ1.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromServices] DataContext context,
                                                            [FromBody] Product input)
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(input);
                await context.SaveChangesAsync();
                return input;
            }
            else
            {
                return NotFound(ModelState);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteById([FromServices] DataContext context, int id)
        {
            var product = context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}