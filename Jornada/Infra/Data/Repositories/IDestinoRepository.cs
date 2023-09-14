using Jornada.Models;

namespace Jornada.Infra.Data.Repositories
{
    public interface IDestinoRepository
    {
        Task<List<Destino>> GetAsync();
        Task<Destino> GetByIDAsync(Guid id);
        Task<Destino> GetByNameAsync(string name);
    }
}