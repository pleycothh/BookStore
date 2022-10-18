using ConsoleWebApi.Models;
using ConsoleWebApi.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace ConsoleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            var result = _productRepository.AddProduct(product);
            var all = _productRepository.GetAllProducts();
            return Ok(all);
        }

      //  [HttpGet("")]
      //  public IActionResult GetAddProduct([FromBody] ProductModel product)
      //  {
      //      var result = _productRepository.AddProduct(product);
      //      if (result > 0) return Ok(result);
      //      else return BadRequest();
      //  }
    }
}
