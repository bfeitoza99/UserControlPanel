using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;

namespace UserControlPanel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdressController : ControllerBase
    {
        [HttpGet("{cep}")]
        public async Task<IActionResult> Get([FromServices] IMediator mediator,
                                                    [FromServices] ILogger<UserAdressController> _logger,
                                                    string cep)
        {
            try
            {
                _logger.LogInformation($"Get Adress by cep: {cep}");
                var command = new UserAdressQueryRequest(cep);
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
