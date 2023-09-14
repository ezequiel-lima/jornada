using Jornada.Models;

namespace Jornada.Infra.Data
{
    public interface IUnitOfWork
    {
        IApplicationRepository<Declaracao> DeclaracaoRepository { get; }
        IApplicationRepository<Destino> DestinoRepository { get; }
        IApplicationRepository<Foto> FotoRepository { get; }

        void Dispose();
        void Save();
    }
}