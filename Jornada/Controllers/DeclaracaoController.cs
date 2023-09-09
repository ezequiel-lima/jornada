using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jornada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeclaracaoController : ControllerBase
    {
        private readonly IHandler<CreateDeclaracaoCommand> _createDeclaracaoHandler;

        public DeclaracaoController(IHandler<CreateDeclaracaoCommand> createDeclaracaoHandler)
        {
            _createDeclaracaoHandler = createDeclaracaoHandler;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDeclaracaoCommand command)
        {
            try
            {
                var result = _createDeclaracaoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
