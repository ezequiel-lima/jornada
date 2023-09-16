using Jornada.Commands;
using Jornada.Commands.Declaracoes;
using Jornada.Commands.Interfaces;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data;
using Jornada.Infra.Data.Repositories;
using Jornada.Models;

namespace Jornada.Handlers.Declaracoes
{
    public class UpdateDeclaracaoHandler : IHandler<UpdateDeclaracaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeclaracaoRepository _declaracaoRepository;

        public UpdateDeclaracaoHandler(IUnitOfWork unitOfWork, IDeclaracaoRepository declaracaoRepository)
        {
            _unitOfWork = unitOfWork;
            _declaracaoRepository = declaracaoRepository;
        }

        public async Task<ICommandResult> Handle(UpdateDeclaracaoCommand command)
        {
            //QUIEL
            //command.Validate();

            var declaracao = await _declaracaoRepository.GetByIDAsync(command.Id);
            await RemoverFotoAntiga(declaracao);

            _unitOfWork.FotoRepository.Insert(command.Fotos[0]);

            declaracao.Alterar(command.Fotos, command.Depoimento, command.NomeDoAutor);

            _unitOfWork.DeclaracaoRepository.Update(declaracao);
            _unitOfWork.Save();

            return new CommandResult(true, "Declaração alterado com sucesso", declaracao);
        }

        private async Task RemoverFotoAntiga(Declaracao declaracao)
        {
            foreach (var fotoAntiga in declaracao.Fotos)
            {
                var foto = await _unitOfWork.FotoRepository.GetByIDAsync(fotoAntiga.Id);
                _unitOfWork.FotoRepository.Delete(foto);
            }
        }
    }
}
