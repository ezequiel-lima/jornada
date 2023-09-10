using Jornada.Models;

namespace Jornada.Infra.Data
{
    public interface IUnitOfWork
    {
        IApplicationRepository<Declaracao> DeclaracaoRepository { get; }
        IApplicationRepository<Destino> DestinoRepository { get; }

        void Dispose();
        void Save();
    }
}