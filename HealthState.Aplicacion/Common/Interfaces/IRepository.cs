using System.Linq.Expressions;

namespace HealthState.Aplicacion.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                                            int? take = null, int? skip = null, bool onlyDistinct = false,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string[] includeProperties = null, bool asNotTracking = false);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> columns,
                                                        Expression<Func<T, bool>> filter = null,
                                                        int? take = null, int? skip = null, bool onlyDistinct = false,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                        string[] includeProperties = null);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByKeyAsync(params object[] key);
        Task<T> InsertAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);
        Task DeleteAsync(params object[] key);
        void Delete(T entityToDelete);
        void DeleteSoft(T entityToDelete);

        Task<T> FirstAsync(Expression<Func<T, bool>> filter = null,
                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                 string[] includeProperties = null, bool notTacking = false);
        Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null);
        void DeleteMany(IEnumerable<T> entitiesToDelete);
        void UpdateAsync(T entityToUpdate);

        Task<IEnumerable<T>> FromSqlRawAsync(string sql, params object[] parameters);
    }
}
