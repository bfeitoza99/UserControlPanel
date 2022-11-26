using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        

        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }

       
    }
}
