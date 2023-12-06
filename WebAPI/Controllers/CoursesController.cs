using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetDetailsList")]
        public async Task<IActionResult> GetDetailsList()
        {
            var result = await _courseService.GetDetailsListAsync();
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Course course)
        {
            await _courseService.Add(course);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete( Course course)
        {
            await _courseService.Delete(course);
            return Ok();
        }
    }
}
