using Jornada.Commands;
using Jornada.Commands.Destinos;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;
using Jornada.Models;

namespace Jornada.Handlers.Destinos
{
    public class CreateDestinoHandler : IHandler<CreateDestinoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDestinoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(CreateDestinoCommand command)
        {
            //QUIEL     
            //command.Validate();

            var destino = new Destino(command.Nome, command.Meta, command.TextoDescritivo, command.Preco);
            _unitOfWork.DestinoRepository.Insert(destino);
            _unitOfWork.Save();

            return new CommandResult(true, "Destino cadastrado com sucesso", destino);
        }
    }
}
