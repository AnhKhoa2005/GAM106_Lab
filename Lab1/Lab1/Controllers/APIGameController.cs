using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIGameController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string data = "Hello, API back-end";
            return new JsonResult(data);
        }

        [HttpGet("getmodel")]
        public IActionResult GetModel()
        {
            GameModel gameModel = new GameModel { 
                CourseName = "Back-end",
                CourseCode = "Game106",
                Name = "Khoa",
                StudentCode = "PD12001",
                Class = "Game20301"
            };

            int status = 1;
            string message = "Get data success!";
            var data = new { status, message, gameModel };
            return new JsonResult(data);
        }
    }
}
