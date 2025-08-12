using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _service.GetById(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _service.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }
        
        [HttpPatch("{id}")]
public IActionResult PartialUpdate(int id, [FromBody] Student updates)
{
    if (_service.PartialUpdate(id, updates))
        return Ok(new { message = "Student updated successfully" });

    return NotFound(new { message = "Student not found" });
}



      [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    if (_service.Delete(id))
        return Ok(new { message = "Student deleted successfully" });

    return NotFound(new { message = "Student not found" });
}

    }
}
