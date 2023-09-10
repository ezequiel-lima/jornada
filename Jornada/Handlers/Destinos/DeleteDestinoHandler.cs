using Jornada.Commands.Interfaces;
using Jornada.Commands;
using Jornada.Infra.Data;
using Jornada.Commands.Destinos;
using Jornada.Handlers.Interfaces;

namespace Jornada.Handlers.Destinos
{
    public class DeleteDestinoHandler : IHandler<DeleteDestinoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDestinoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(DeleteDestinoCommand command)
        {
            //QUIEL
            //command.Validate();

            var destino = _unitOfWork.DestinoRepository.GetByID(command.Id);

            _unitOfWork.DestinoRepository.Delete(destino);
            _unitOfWork.Save();

            return new CommandResult(true, "Destino deletado com sucesso", destino);
        }
    }
}
