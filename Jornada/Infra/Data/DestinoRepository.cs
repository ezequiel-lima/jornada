using Jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace Jornada.Infra.Data
{
    public class DestinoRepository : IDisposable, IDestinoRepository
    {
        private DataContext _context;

        public DestinoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Destino> GetDestinos()
        {
            return _context.Destinos.ToList();
        }

        public async Task<Destino> GetByNameAsync(string name)
        {
            return await _context.Destinos.FirstOrDefaultAsync(x => x.Nome == name);
        }

        public Destino GetStudentByID(Guid id)
        {
            return _context.Destinos.Find(id);
        }

        public void InsertDestino(Destino destino)
        {
            _context.Destinos.Add(destino);
        }

        public void DeleteDestino(Guid destinoID)
        {
            Destino destino = _context.Destinos.Find(destinoID);
            _context.Destinos.Remove(destino);
        }

        public void UpdateDestino(Destino destino)
        {
            _context.Entry(destino).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
