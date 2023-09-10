using Jornada.Models;

namespace Jornada.Infra.Data
{
    public interface IDestinoRepository
    {
        void DeleteDestino(Guid destinoID);
        void Dispose();
        Task<Destino> GetByNameAsync(string name);
        IEnumerable<Destino> GetDestinos();
        Destino GetStudentByID(Guid id);
        void InsertDestino(Destino destino);
        void Save();
        void UpdateDestino(Destino destino);
    }
}