using ConsoleWebApi.Models;
using ConsoleWebApi.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("")]
        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>() {
                new EmployeeModel() {Id= 1, Name = "emp 1" },
                new EmployeeModel() {Id= 2, Name = "emp 2" },
                new EmployeeModel() {Id= 3, Name = "emp 3" },
                new EmployeeModel() {Id= 4, Name = "emp 4" }
            };
        }

        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
            return id == 0 ? NotFound() : Ok(

                new List<EmployeeModel>() {
                new EmployeeModel() {Id= id, Name = $"emp {id}" },
                new EmployeeModel() {Id= id+1, Name = $"emp {id+1}" }
                });
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeesDetails(int id)
        {
            return id == 0 ? NotFound() : Ok(

                new EmployeeModel() {Id= id, Name = $"emp {id}" }
                );
        }

        // dependency injection to the action level
        [HttpPost("product")]
        public IActionResult AddProduct([FromServices] IProductRepository _productRepository, ProductModel product)
        {
            _productRepository.AddProduct(product);
            
            var all = _productRepository.GetAllProducts();
            return Ok(all);
        }
    }
}
