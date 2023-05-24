using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptersController : ControllerBase
    {
        private readonly IAdopterService _adopterService;

        public AdoptersController(IAdopterService adopterService)
        {
            _adopterService = adopterService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _adopterService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _adopterService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Adopter adopter)
        {
            var result = _adopterService.Add(adopter);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _adopterService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, [FromBody] Adopter adopter)
        {
            adopter.AdopterId = id;
            var result = _adopterService.Update(id, adopter);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
