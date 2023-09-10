using System.Linq.Expressions;

namespace Jornada.Infra.Data
{
    public interface IApplicationRepository<T> where T : class
    {    
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetByID(object id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task<T> GetByIDAsync(object id);
        Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        void Insert(T entity);
        void Update(T entityToUpdate);
        void Delete(object id);
        void Delete(T entityToDelete);
    }
}