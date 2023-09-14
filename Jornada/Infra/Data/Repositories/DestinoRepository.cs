using Jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace Jornada.Infra.Data.Repositories
{
    public class DestinoRepository : IDestinoRepository
    {
        private DataContext _context;

        public DestinoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Destino>> GetAsync()
        {
            return await _context.Destinos.AsNoTracking().Include(x => x.Fotos).ToListAsync();
        }

        public async Task<Destino> GetByIDAsync(Guid id)
        {
            return await _context.Destinos.AsNoTracking().Include(x => x.Fotos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Destino> GetByNameAsync(string name)
        {
            return await _context.Destinos.AsNoTracking().Include(x => x.Fotos).FirstOrDefaultAsync(x => x.Nome == name);
        }
    }
}
