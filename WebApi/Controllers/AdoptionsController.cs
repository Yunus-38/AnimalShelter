using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionsController : ControllerBase
    {
        private readonly IAdoptionService _adoptionService;

        public AdoptionsController(IAdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _adoptionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _adoptionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Adoption adoption)
        {
            var result = _adoptionService.Add(adoption);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(int id, Adoption adoption)
        {
            adoption.AdoptionId = id;
            var result = _adoptionService.Update(id, adoption);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _adoptionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}
