using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Infraestructura.Data;

namespace HealthState.Infraestructura.Repository
{
    public class UnitOfWork(HealthStateDbContext context) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> repositories = [];

        public IRepository<T> GetRepository<T>() where T : class
        {

            if (repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)repositories[typeof(T)];
            }

            var repository = new Repository<T>(context);
            repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
    }
}