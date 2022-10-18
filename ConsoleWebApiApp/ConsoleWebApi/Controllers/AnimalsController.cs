using ConsoleWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly List<AnimalModel> _animals;

        public AnimalsController()
        {
            _animals = new List<AnimalModel>()
            {
                new AnimalModel() {Id = 1, Name = "dog" },
                new AnimalModel() {Id = 2, Name = "cat" } ,
                new AnimalModel() {Id = 3, Name = "cow" }
            };
        }
        [Route("", Name = "All")]
        public IActionResult GetAnimals()
        {
            return Ok(_animals);
        }

        [Route("test")]
        public IActionResult GetAnimalsTest()
        {
          //  return Accepted(animals);
            return AcceptedAtRoute("All");
        }

        [Route("bad")]
        public IActionResult GetAnimalsBad()
        {
            return BadRequest(_animals);
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if (id == 0) return BadRequest("id can not be 0");
            
            var animal = _animals.FirstOrDefault(x => x.Id == id);

            if(animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost("")]
        public IActionResult GetAnimals(AnimalModel animal)
        {
            _animals.Add(animal);

         //   return Created("~/api/animals/", new { id = animal.Id } ,animal);
            return CreatedAtAction("GetAnimalsById", new { id = animal.Id } ,animal);
        }





    }
}
