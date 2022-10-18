using ConsoleWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [BindProperty(SupportsGet = true)]
        public CountryModel country { get; set; }

        [HttpPost("")]
        public IActionResult AddCountry()
        {
            return Ok($"Name = {this.country.Name}, Population = {this.country.Population}, Area {this.country.Area}");
        }

        /// by default using query string to pass the data
        [HttpGet("")]
        [HttpGet("{area}/{name}/{id}")]// <- if url key does not match the input key, pass as query, else pass from URL
        public IActionResult GetCountryById(int id, string name, int area)
        {

            return Ok($"Name = {name}, id = {id}, Area {area}");
        }

        // From Header only works in Post??
        [HttpPost("{name}")]
        public IActionResult GetCountryName([FromRoute] string name)
        {
            return Ok(name);
        }

        // From Header only works in Post??
        [HttpGet("search")]
        public IActionResult SearchCountries([ModelBinder(typeof(CustomBinder))]string[] countries)
        {
            return Ok(countries);
        }

        // From Header only works in Post??
        [HttpGet("{id}")]
        public IActionResult CountryDetails ([ModelBinder(Name ="id")]CountryModel country)
        {
            return Ok(country);
        }


    }
}
