using Example.Ecommerce.Application.Interface.Persistence;
using Example.Ecommerce.Application.Interface.Persistence.Parametrization;
using Example.Ecommerce.Application.Interface.Persistence.Petition;
using Example.Ecommerce.Persistence.Repositories.Parametrization;
using Example.Ecommerce.Persistence.Repositories.Petition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Example.Ecommerce.Application.DTO.Common;
using Example.Ecommerce.Persistence.Contexts.SqlServer;
using Example.Ecommerce.Persistence.Contexts.Mysql;

namespace Example.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly MysqlApplicationDbContext _context;
        private bool _disposed;

        #region Repositories

        #region Parametrization

        private readonly IStateRepository _stateRepository = null!;
        public IStateRepository StateRepository { get { return _stateRepository ?? new StateRepository(_context); } }

        private readonly IIdentificationTypeRepository _identificationTypeRepository = null!;
        public IIdentificationTypeRepository IdentificationTypeRepository { get
            { return _identificationTypeRepository ?? new IdentificationTypeRepository(_context); }
        }

        #endregion

        #region Petition

        private readonly IPetitionRepository _petitionRepository = null!;
        public IPetitionRepository PetitionRepository { get { return _petitionRepository ?? new PetitionRepository(_context); } }

        private readonly IHeadLineRepository _headLineRepository = null!;
        public IHeadLineRepository HeadLineRepository { get { return _headLineRepository ?? new HeadLineRepository(_context); } }

        private readonly IBeneficiaryRepository _beneficiaryRepository = null!;
        public IBeneficiaryRepository BeneficiaryRepository { get { return _beneficiaryRepository ?? new BeneficiaryRepository(_context); } }

        #endregion

        #endregion

        public UnitOfWork(MysqlApplicationDbContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() { _ = DisposeAsync(false); }

        protected async virtual ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) await _context.DisposeAsync();

                _disposed = true;
            }
        }

        public async Task<int> Save(CancellationToken cancellationToken = default) =>
            await _context.SaveChangesAsync(cancellationToken);

        public void RejectChanges()
        {
            _context.ChangeTracker.Entries().Where(e => e.State is not EntityState.Unchanged).ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added: entry.State = EntityState.Detached; break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            });
        }

        #region Execute Raw SQL

        public async Task<IEnumerable<T>> ExecuteEnumerableSP<T>(string spName, List<SqlParam> parameters)
        {
            using DbCommand command = _context.Database.GetDbConnection().CreateCommand();

            parameters.ForEach(p =>
            {
                SqlParameter sqlParameter = new (p.Name, p.Value) { SqlDbType = p.Config!.DataType };
                command.Parameters.Add(sqlParameter);
            });

            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;

            if (command.Connection!.State is not ConnectionState.Open) await command.Connection!.OpenAsync();

            //command.Transaction = _context.Database.BeginTransaction().GetDbTransaction()
            //command.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction()

            try
            {
                using DbDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

                List<T> data = MapToList<T>(reader);

                await reader.CloseAsync();

                return data;

                //await command.Transaction!.CommitAsync()
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
                //await command.Transaction!.RollbackAsync()
            }
            finally
            {
                if (command.Connection!.State is ConnectionState.Open)
                    await command.Connection!.CloseAsync();

                //await command.DisposeAsync()
            }
        }

        private static List<T> MapToList<T>(DbDataReader dbDataReader)
        {
            List<T> Response = new();

            IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
            Dictionary<string, DbColumn> colMapping =
                dbDataReader.GetColumnSchema()
                    .Where(c => props.Any(y => y.Name.ToLower()!.Equals(c.ColumnName!.ToLower())))
                    .ToDictionary(key => key.ColumnName.ToLower());

            if (dbDataReader.HasRows)
            {
                while (dbDataReader.Read())
                {
                    T objClass = Activator.CreateInstance<T>();

                    foreach ((PropertyInfo prop, object val) in
                        from PropertyInfo prop in props
                        where colMapping.ContainsKey(prop.Name.ToLower())
                        let val = dbDataReader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal!.Value)
                        select (prop, val)
                    )
                    {
                        prop.SetValue(objClass, val.Equals(DBNull.Value) ? null : val);
                    }

                    Response.Add(objClass);
                }
            }

            dbDataReader.Dispose();

            return Response;
        }

        #endregion

        #region Transaction

        public async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _context.Database.BeginTransactionAsync();

        public async Task CommitAsync(IDbContextTransaction transaction) =>
            await transaction.CommitAsync();

        public async Task RollbackAsync(IDbContextTransaction transaction) =>
            await transaction.RollbackAsync();

        #endregion
    }
}