using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;

namespace Jornada.Handlers.Declaracoes
{
    public class UpdateDeclaracaoHandler : IHandler<UpdateDeclaracaoCommand>
    {
        private readonly UnitOfWork _unitOfWork;

        public UpdateDeclaracaoHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(UpdateDeclaracaoCommand command)
        {
            //QUIEL
            //command.Validate();

            var declaracao = await _unitOfWork.DeclaracaoRepository.GetByIDAsync(command.Id);
            declaracao.Alterar(command.Foto, command.Depoimento, command.NomeDoAutor);

            _unitOfWork.DeclaracaoRepository.Update(declaracao);
            _unitOfWork.Save();

            return new CommandResult(true, "Declaração alterado com sucesso", declaracao);
        }
    }
}
