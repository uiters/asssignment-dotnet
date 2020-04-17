using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteServiceCore.Model;

namespace RemoteServiceCore.Controllers
{
    public class ProductsController : ControllerBase
    {
        [Route("api/[controller]")]
        public IEnumerable<Product> Get()
        {
            return ProductData.ProductList;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product p = ProductData.ProductList.SingleOrDefault(x => x.ProductID == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost()]
        public void Post([FromBody] Product product)
        {
            ProductData.ProductList.Add(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Product p = ProductData.ProductList.SingleOrDefault(x => x.ProductID == id);
            ProductData.ProductList.Remove(p);
        }
    }
}