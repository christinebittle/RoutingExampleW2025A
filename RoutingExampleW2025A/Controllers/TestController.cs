using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingExampleW2025A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        // GET : localhost:xx/api/Test/{id}
        // GET : localhost:xx/api/Test/4 -> 5
        [HttpGet]
        [Route(template:"/api/Test/{id}")]
        public int Get(int id)
        {
            return id+1;
        }

    }
}
