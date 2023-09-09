using Jornada.Models;

namespace Jornada.Infra.Data
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _context;
        private ApplicationRepository<Declaracao> _declaracaoRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ApplicationRepository<Declaracao> DeclaracaoRepository
        {
            get
            {
                if (this._declaracaoRepository == null)
                {
                    this._declaracaoRepository = new ApplicationRepository<Declaracao>(_context);
                }
                return _declaracaoRepository;
            }
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
