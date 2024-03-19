using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;
        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetCustomers()
        {
            return _productDbContext.Products;
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product?>> GetById(int productId)
        {
            var customer = await _productDbContext.Products.FindAsync(productId);
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product customer)
        {
            await _productDbContext.Products.AddAsync(customer);
            await _productDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product customer)
        {
            _productDbContext.Products.Update(customer);
            await _productDbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _productDbContext.Products.FindAsync(productId);
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
