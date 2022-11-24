using Microsoft.AspNetCore.Mvc;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGenderController :  ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
