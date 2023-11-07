using Microsoft.AspNetCore.Mvc;

namespace TeacherWAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        

        [HttpGet("[action]")]
        public IActionResult GetTeacher()
        {
            return Ok(new List<string> { "Teacher 1", "Teacher 2", "Teacher 3", "Teacher 4" });
        }
    }
}