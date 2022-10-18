using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebApi.Controllers
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController: ControllerBase
    {
        public string Get()
        {
            return "Hello from Get"; // <- resource
        }

            
        public string GetOne()
        {
            return "Hello from Get one"; // <- resource
        }

    }
}
