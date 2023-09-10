using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;

namespace Jornada.Handlers.Declaracoes
{
    public class DeleteDeclaracaoHandler : IHandler<DeleteDeclaracaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeclaracaoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(DeleteDeclaracaoCommand command)
        {
            //QUIEL
            //command.Validate();

            var declaracao = _unitOfWork.DeclaracaoRepository.GetByID(command.Id);

            _unitOfWork.DeclaracaoRepository.Delete(declaracao);
            _unitOfWork.Save();

            return new CommandResult(true, "Declaração deletada com sucesso", declaracao);
        }
    }
}
