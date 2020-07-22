using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebTwoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Web Two!";
        }
    }
}
