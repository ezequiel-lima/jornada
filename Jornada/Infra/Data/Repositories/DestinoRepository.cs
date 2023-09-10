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

        public async Task<Destino> GetByNameAsync(string name)
        {
            return await _context.Destinos.FirstOrDefaultAsync(x => x.Nome == name);
        }
    }
}
