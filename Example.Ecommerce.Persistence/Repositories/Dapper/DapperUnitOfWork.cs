using Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper;
using Example.Ecommerce.Persistence.Contexts;
using System.Collections;
using System.Data;

namespace Example.Ecommerce.Persistence.Repositories.Dapper
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly IDbConnection _context;
        private bool _disposed;

        public DapperUnitOfWork(DapperApplicationDbContext context)
        {
            _context = context.CreateConnection();
        }

        public IDapperBaseRepository<T> DapperRepository<T>() where T : class
        {
            string type = typeof(T).Name;
            _repositories ??= new Hashtable();

            if (!_repositories.ContainsKey(type))
            {
                Type repositoryType = typeof(DapperBaseRepository<>);
                object? repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IDapperBaseRepository<T>)_repositories[type]!;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();

                _disposed = true;
            }
        }
    }
}