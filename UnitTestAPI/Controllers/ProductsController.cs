using Microsoft.AspNetCore.Mvc;
using UnitTestAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Products> Products = new List<Products>
        {
            new Products { Id = 1, Name = "Laptop", Price = 1200.00M },
            new Products { Id = 2, Name = "Mouse", Price = 25.50M }
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Products);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            if (product == null)
                return BadRequest("Product is null.");

            product.Id = Products.Count + 1;
            Products.Add(product);
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }
    }
}
