using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Application.Query.UserGender;
using UserControlPanel.Application.Command.User;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGenderController :  ControllerBase
    {
        

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(UserGenderQueryRequest), StatusCodes.Status200OK)]

        public async Task<IActionResult> Get([FromServices] IMediator mediator,
                                                    [FromServices] ILogger<UserGenderController> _logger)
        {
            try
            {
                _logger.LogInformation($"Get all genders");
                var command = new UserGenderQueryRequest();                
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }
    }
}
