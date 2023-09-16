using Jornada.Models;

namespace Jornada.Infra.Data.Repositories
{
    public interface IDeclaracaoRepository
    {
        Task<List<Declaracao>> GetAsync();
        Task<Declaracao> GetByIDAsync(Guid id);
        Task<List<Declaracao>> GetPagedAsync(int page, int pageSize);
    }
}