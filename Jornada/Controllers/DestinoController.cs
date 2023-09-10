using Jornada.Commands;
using Microsoft.AspNetCore.Mvc;
using Jornada.Infra.Data;
using Jornada.Commands.Destinos;
using Jornada.Handlers.Interfaces;

namespace Jornada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHandler<CreateDestinoCommand> _createDestinoHandler;

        public DestinoController(IUnitOfWork unitOfWork, IHandler<CreateDestinoCommand> createDestinoHandler)
        {
            _unitOfWork = unitOfWork;
            _createDestinoHandler = createDestinoHandler;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDestinoCommand command)
        {
            try
            {
                var result = await _createDestinoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 01xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }
    }
}
