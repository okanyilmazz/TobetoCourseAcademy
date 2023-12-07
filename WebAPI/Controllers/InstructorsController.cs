using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet("GetDetailsList")]
        public async Task<IActionResult> GetDetailsList()
        {
            var result = await _instructorService.GetDetailsListAsync();
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _instructorService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Instructor instructor)
        {
            await _instructorService.AddAsync(instructor);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Instructor instructor)
        {
            await _instructorService.DeleteAsync(instructor);
            return Ok();
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Instructor instructor)
        {
            await _instructorService.UpdateAsync(instructor);
            return Ok();
        }
    }
}
