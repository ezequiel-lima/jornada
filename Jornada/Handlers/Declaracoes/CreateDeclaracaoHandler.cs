using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;
using Jornada.Models;

namespace Jornada.Handlers.Declaracoes
{
    public class CreateDeclaracaoHandler : IHandler<CreateDeclaracaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeclaracaoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(CreateDeclaracaoCommand command)
        {
            //QUIEL
            //command.Validate();

            var declaracao = new Declaracao(command.Fotos, command.Depoimento, command.NomeDoAutor);

            foreach (var foto in declaracao.Fotos)
            {
                _unitOfWork.FotoRepository.Insert(foto);
            }

            _unitOfWork.DeclaracaoRepository.Insert(declaracao);
            _unitOfWork.Save();

            return new CommandResult(true, "Declaração realizada com sucesso", declaracao);
        }
    }
}
