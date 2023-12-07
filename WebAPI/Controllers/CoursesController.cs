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

        [HttpGet("GetDetailsWithStudentAndInstructorListAsync")]
        public async Task<IActionResult> GetDetailsWithStudentAndInstructorListAsync()
        {
            var result = await _courseService.GetDetailsWithStudentAndInstructorListAsync();
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
            await _courseService.AddAsync(course);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Course course)
        {
            await _courseService.DeleteAsync(course);
            return Ok();
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Course course)
        {
            await _courseService.UpdateAsync(course);
            return Ok();
        }
    }
}
