using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;
using Jornada.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jornada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeclaracaoController : ControllerBase
    {
        private readonly IHandler<CreateDeclaracaoCommand> _createDeclaracaoHandler;
        private readonly IHandler<UpdateDeclaracaoCommand> _updateDeclaracaoHandler;
        private readonly IHandler<DeleteDeclaracaoCommand> _deleteDeclaracaoHandler;
        private readonly IDeclaracaoRepository _declaracaoRepository;

        public DeclaracaoController(IHandler<CreateDeclaracaoCommand> createDeclaracaoHandler, IHandler<UpdateDeclaracaoCommand> updateDeclaracaoHandler, IHandler<DeleteDeclaracaoCommand> deleteDeclaracaoHandler, IDeclaracaoRepository declaracaoRepository)
        {
            _createDeclaracaoHandler = createDeclaracaoHandler;
            _updateDeclaracaoHandler = updateDeclaracaoHandler;
            _deleteDeclaracaoHandler = deleteDeclaracaoHandler;
            _declaracaoRepository = declaracaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _declaracaoRepository.GetAsync();
                var commandResult = new CommandResult(true, "Declarações recuperadas com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 01xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpGet("Home")]
        public async Task<IActionResult> GetHomeAsync(int page = 1, int take = 3)
        {
            try
            {
                var result = await _declaracaoRepository.GetPagedAsync(page, take);
                var commandResult = new CommandResult(true, "Declaração recuperada com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 02xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _declaracaoRepository.GetByIDAsync(id);
                var commandResult = new CommandResult(true, "Declaração recuperada com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 03xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateDeclaracaoCommand command)
        {
            try
            {
                var result = await _createDeclaracaoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 04xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateDeclaracaoCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _updateDeclaracaoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 05xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, DeleteDeclaracaoCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _deleteDeclaracaoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(false, "Erro 06xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

    }
}
