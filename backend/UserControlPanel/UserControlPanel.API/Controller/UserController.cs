using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

       
    }
}
