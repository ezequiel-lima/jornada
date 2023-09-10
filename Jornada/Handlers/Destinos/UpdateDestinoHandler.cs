using Jornada.Commands;
using Jornada.Commands.Destinos;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;

namespace Jornada.Handlers.Destinos
{
    public class UpdateDestinoHandler : IHandler<UpdateDestinoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDestinoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(UpdateDestinoCommand command)
        {
            // QUIEL
            //command.Validate();

            var destino = await _unitOfWork.DestinoRepository.GetByIDAsync(command.Id);
            destino.Alterar(command.Foto, command.Nome, command.Preco);

            _unitOfWork.DestinoRepository.Update(destino);
            _unitOfWork.Save();

            return new CommandResult(true, "Destino alterado com sucesso", destino);
        }
    }
}
