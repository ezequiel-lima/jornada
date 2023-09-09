﻿using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Jornada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeclaracaoController : ControllerBase
    {
        private readonly IHandler<CreateDeclaracaoCommand> _createDeclaracaoHandler;
        private readonly IHandler<UpdateDeclaracaoCommand> _updateDeclaracaoHandler;
        private readonly IHandler<DeleteDeclaracaoCommand> _deleteDeclaracaoHandler;
        private readonly UnitOfWork _unitOfWork;

        public DeclaracaoController(IHandler<CreateDeclaracaoCommand> createDeclaracaoHandler, IHandler<UpdateDeclaracaoCommand> updateDeclaracaoHandler, IHandler<DeleteDeclaracaoCommand> deleteDeclaracaoHandler, UnitOfWork unitOfWork)
        {
            _createDeclaracaoHandler = createDeclaracaoHandler;
            _updateDeclaracaoHandler = updateDeclaracaoHandler;
            _deleteDeclaracaoHandler = deleteDeclaracaoHandler;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.DeclaracaoRepository.GetAsync();
                var commandResult = new CommandResult(true, "Declarações recuperadas com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 01xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _unitOfWork.DeclaracaoRepository.GetByIDAsync(id);
                var commandResult = new CommandResult(true, "Declaração recuperada com sucesso", result);
                return Ok(commandResult);
            }
            catch (Exception exception)
            {
                var commandResult = new CommandResult(true, "Erro 02xDE", exception.Message);
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
                var commandResult = new CommandResult(true, "Erro 03xDE", exception.Message);
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
                var commandResult = new CommandResult(true, "Erro 04xDE", exception.Message);
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
                var commandResult = new CommandResult(true, "Erro 04xDE", exception.Message);
                return BadRequest(commandResult);
            }
        }

    }
}