using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Application.Command.User;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpPost]
        [ProducesResponseType(typeof(UserCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IMediator mediator,
                                                    [FromServices] ILogger<UserAdressController> _logger,
                                                    UserCommandRequest command)
        {
            try
            {
                _logger.LogInformation($"Save a new user with name: {command.Name}");                
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
