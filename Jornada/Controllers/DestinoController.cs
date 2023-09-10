using Jornada.Commands;
using Microsoft.AspNetCore.Mvc;
using Jornada.Infra.Data;
using Jornada.Commands.Destinos;
using Jornada.Handlers.Interfaces;
using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Declaracoes;
using Jornada.Infra.Data.Repositories;

namespace Jornada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHandler<CreateDestinoCommand> _createDestinoHandler;
        private readonly IHandler<UpdateDestinoCommand> _updateDestinoHandler;
        private readonly IHandler<DeleteDestinoCommand> _deleteDestinoHandler;
        private readonly IDestinoRepository _destinoRepository;

        public DestinoController(IUnitOfWork unitOfWork, IHandler<CreateDestinoCommand> createDestinoHandler, IDestinoRepository destinoRepository, IHandler<UpdateDestinoCommand> updateDestinoHandler, IHandler<DeleteDestinoCommand> deleteDestinoHandler)
        {
            _unitOfWork = unitOfWork;
            _createDestinoHandler = createDestinoHandler;
            _destinoRepository = destinoRepository;
            _updateDestinoHandler = updateDestinoHandler;
            _deleteDestinoHandler = deleteDestinoHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.DestinoRepository.GetAsync();
                var commandResult = new CommandResult(true, "Destinos recuperados com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 01xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _unitOfWork.DestinoRepository.GetByIDAsync(id);
                var commandResult = new CommandResult(true, "Destino recuperado com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 02xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpGet("By-name/{nome}")]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            try
            {
                var result = await _destinoRepository.GetByNameAsync(nome);

                if (result is null)
                    return Ok(new CommandResult(false, "Nenhum destino foi encontrado"));

                var commandResult = new CommandResult(true, "Destino recuperado com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 03xDT", exception.Message);
                return BadRequest(commandResult);
            }
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
                var commandResult = new CommandResult(true, "Erro 04xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateDestinoCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _updateDestinoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 05xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, DeleteDestinoCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _deleteDestinoHandler.Handle(command);
                return Ok(result);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 06xDT", exception.Message);
                return BadRequest(commandResult);
            }
        }
    }
}
