using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Persistence;
using Example.Ecommerce.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Example.Ecommerce.Persistence.Repositories.EfCore;

public class EfUnitOfWork : IEfUnitOfWork
{
    protected readonly EfApplicationDbContext _context;
    private Hashtable? _repositories;
    private bool _disposed;

    public EfUnitOfWork(EfApplicationDbContext context) =>
        _context = context ?? throw new ArgumentNullException(nameof(context));

    #region Repositories

    public IEfBaseRepository<T> EfRepository<T>() where T : BaseDomainEntity
    {
        string type = typeof(T).Name;
        _repositories ??= new Hashtable();

        if (!_repositories.ContainsKey(type))
        {
            Type repositoryType = typeof(EfBaseRepository<>);
            object? repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IEfBaseRepository<T>)_repositories[type]!;
    }

    #endregion Repositories

    #region Dispose

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    protected async virtual ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing) await _context.DisposeAsync();

            _disposed = true;
        }
    }

    #endregion Dispose

    #region Methods

    public async Task<int> EfSave(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken);

    public void EfRejectChanges()
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

    #region Execute Raw SP

    public async Task<IReadOnlyList<T>> EfExecuteEnumerableSP<T>(string spName, List<SqlParam> parameters)
    {
        using DbCommand command = _context.Database.GetDbConnection().CreateCommand();

        parameters.ForEach(p =>
        {
            SqlParameter sqlParameter = new(p.Name, p.Value) { SqlDbType = p.Config!.DataType };
            command.Parameters.Add(sqlParameter);
        });

        command.CommandText = spName;
        command.CommandType = CommandType.StoredProcedure;

        if (command.Connection!.State is not ConnectionState.Open) await command.Connection!.OpenAsync();

        try
        {
            using DbDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

            List<T> data = EfMapToList<T>(reader);
            await reader.CloseAsync();

            return data;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
        finally
        {
            if (command.Connection!.State is ConnectionState.Open)
                await command.Connection!.CloseAsync();
        }
    }

    private static List<T> EfMapToList<T>(DbDataReader dbDataReader)
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

    #endregion Execute Raw SP

    #region Transaction

    public async Task<IDbContextTransaction> EfBeginTransactionAsync() =>
        await _context.Database.BeginTransactionAsync();

    public async Task EfCommitAsync(IDbContextTransaction transaction) =>
        await transaction.CommitAsync();

    public async Task EfRollbackAsync(IDbContextTransaction transaction) =>
        await transaction.RollbackAsync();

    #endregion Transaction

    #endregion Methods
}