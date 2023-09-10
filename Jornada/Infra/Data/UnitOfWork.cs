using Jornada.Models;

namespace Jornada.Infra.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataContext _context;
        private IApplicationRepository<Declaracao> _declaracaoRepository;
        private IApplicationRepository<Destino> _destinoRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IApplicationRepository<Declaracao> DeclaracaoRepository
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

        public IApplicationRepository<Destino> DestinoRepository
        {
            get
            {
                if (this._destinoRepository == null)
                {
                    this._destinoRepository = new ApplicationRepository<Destino>(_context);
                }
                return _destinoRepository;
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
