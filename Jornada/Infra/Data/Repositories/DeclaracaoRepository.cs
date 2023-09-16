using Jornada.Models;
using Microsoft.EntityFrameworkCore;

namespace Jornada.Infra.Data.Repositories
{
    public class DeclaracaoRepository : IDeclaracaoRepository
    {
        private DataContext _context;

        public DeclaracaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Declaracao>> GetAsync()
        {
            return await _context.Declaracoes.AsNoTracking().Include(x => x.Fotos).ToListAsync();
        }

        public async Task<Declaracao> GetByIDAsync(Guid id)
        {
            return await _context.Declaracoes.AsNoTracking().Include(x => x.Fotos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Declaracao>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Declaracoes.AsNoTracking().Include(x => x.Fotos).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
