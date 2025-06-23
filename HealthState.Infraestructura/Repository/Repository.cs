using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Dominio.Types;
using HealthState.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthState.Infraestructura.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HealthStateDbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(HealthStateDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null) => filter == null ? await dbSet.CountAsync() : await dbSet.CountAsync(filter);

        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);

            dbSet.Remove(entityToDelete);
        }

        public async Task DeleteAsync(params object[] key)
        {
            var entityToDelete = await dbSet.FindAsync(key);
            if (entityToDelete != null) Delete(entityToDelete);
        }

        public void DeleteMany(IEnumerable<T> entitiesToDelete)
        {
            if (entitiesToDelete == null) return;

            foreach (var entity in entitiesToDelete)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                    dbSet.Attach(entity);
            }

            dbSet.RemoveRange(entitiesToDelete);
        }

        public void DeleteSoft(T entityToDelete)
        {
            if (entityToDelete is not ISoftDelete) throw new InvalidOperationException("Entity to soft delete must be implement ISoftDelete interface");

            if (context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);
            context.Entry(entityToDelete).State = EntityState.Modified;
            var entity = (ISoftDelete)entityToDelete;

            entity.Deleted = DateTime.Now;
            entity.IsDeleted = true;
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null) return false;
            return await dbSet.AnyAsync(filter);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> filter = null,
                                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null, bool notTracking = false)
        {
            if (filter == null)
            {
                var builder = PredicateBuilder.Build<T>();
                filter = builder.And(x => 1 == 1);
            }

            IQueryable<T> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                    query = query.Include(item);
            }

            if (orderBy != null)
                query = orderBy(query);


            var response = notTracking ? await query.AsNoTracking().FirstOrDefaultAsync(filter) : await query.FirstOrDefaultAsync(filter);

          

            return response;
        }

        public async Task<IEnumerable<T>> FromSqlRawAsync(string sql, params object[] parameters) => await dbSet.FromSqlRaw(sql, parameters).ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, int? take = null, int? skip = null, bool onlyDistinct = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null, bool asNotTracking = false)
        {
            IQueryable<T> query = dbSet;

            if (asNotTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var item in includeProperties)
                    query = query.Include(item);


            if (orderBy != null)
                query = orderBy(query);

            if (take != null && skip != null)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }

            if (onlyDistinct)
                query = query.Distinct();

            return await query.ToListAsync();
        }

        public async Task<T> GetByKeyAsync(params object[] key) => await dbSet.FindAsync(key);

        public async Task InsertAsync(T entity) => await dbSet.AddAsync(entity);

        public async Task InsertManyAsync(IEnumerable<T> entities) => await dbSet.AddRangeAsync(entities);

        public async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> columns, Expression<Func<T, bool>> filter = null, int? take = null, int? skip = null, bool onlyDistinct = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var item in includeProperties)
                query = query.Include(item);

            if (orderBy != null)
                query = orderBy(query);

            var select = query.Select(columns);

            if (onlyDistinct)
                select = select.Distinct();

            if (take != null && skip != null)
                select = select.Skip(skip.Value).Take(take.Value);

            return await select.ToListAsync();
        }

        public void UpdateAsync(T entityToUpdate)
        {
            if (context.Entry(entityToUpdate).State == EntityState.Detached)
                dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}