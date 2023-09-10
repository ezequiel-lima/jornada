using Jornada.Models;

namespace Jornada.Infra.Data.Repositories
{
    public interface IDestinoRepository
    {
        Task<Destino> GetByNameAsync(string name);
    }
}