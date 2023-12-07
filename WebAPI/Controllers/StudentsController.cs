using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetDetailsList")]
        public async Task<IActionResult> GetDetailsList()
        {
            var result = await _studentService.GetDetailsListAsync();
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            await _studentService.AddAsync(student);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Student student)
        {
            await _studentService.DeleteAsync(student);
            return Ok();
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Student student)
        {
            await _studentService.UpdateAsync(student);
            return Ok();
        }
    }
}
