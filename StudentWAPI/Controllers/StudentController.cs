using Microsoft.AspNetCore.Mvc;

namespace StudentWAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GetStudent()
        {
            return Ok(new List<string> { "Student 1", "Student 2", "Student 3", "Student 4" });
        }
    }
}