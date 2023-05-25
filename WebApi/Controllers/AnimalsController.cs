using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _animalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _animalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Animal animal)
        {
            var result = _animalService.Add(animal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _animalService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            var result = _animalService.Update(id, animal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getanimaldetails/{id}")]
        public IActionResult GetAnimalDetails(int id)
        {
            var result = _animalService.GetAnimalDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getadoptedanimals")]
        public IActionResult GetAdoptedAnimals()
        {
            var result = _animalService.GetAdoptedAnimals();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
