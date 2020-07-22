using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebOneController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Web One!";
        }

        [HttpGet("One")]
        public string One()
        {
            return "Hello Web One One!";
        }
    }
}
