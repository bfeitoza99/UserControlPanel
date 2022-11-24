using Microsoft.AspNetCore.Mvc;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdressController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
