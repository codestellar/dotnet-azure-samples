using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codestellar.RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IRedisCacheClient redisCacheClient)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var product = new Product()
            {
                Id = 1,
                Name = "hand sanitizer",
                Price = 100
            };

            bool isAdded = await _redisCacheClient.Db0.AddAsync("Product", product, DateTimeOffset.Now.AddMinutes(10));

            return isAdded?Created: BadRequest("Something went wrong");
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            
                var productdata = await _redisCacheClient.Db0.GetAsync<Product>("Product");
               return Ok(productdata)
           
        }
    }
}
