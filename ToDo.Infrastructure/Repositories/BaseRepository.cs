using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ToDo.Infrastructure.ConfigurationModels;

namespace ToDo.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectionString;
        private readonly int _dapperTimeout;

        public BaseRepository(DBSettings settings)
        {
            _connectionString = settings.ConnectionString;
            _dapperTimeout = settings.DapperTimeout;
        }

        public string GetResourceFile(string name, Assembly assembly)
        {
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public IDbConnection CreateDbConnection()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            return dbConnection;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object sqlParams = null, IDbConnection dbConnection = null, IDbTransaction dbTransaction = null)
        {
            if (dbConnection != null && dbTransaction == null)
            {
                return await dbConnection.QueryAsync<T>(sql, sqlParams, commandTimeout: _dapperTimeout).ConfigureAwait(false);
            }
            else if (dbConnection != null && dbTransaction != null)
            {
                return await dbConnection.QueryAsync<T>(sql, sqlParams, dbTransaction, commandTimeout: _dapperTimeout).ConfigureAwait(false);
            }
            else
            {
                using (IDbConnection dbConn = CreateDbConnection())
                {
                    return await dbConn.QueryAsync<T>(sql, sqlParams, commandTimeout: _dapperTimeout).ConfigureAwait(false);
                }
            }
        }

        public async Task<int> ExecuteAsync(string sql, object sqlParams, IDbConnection dbConnection = null, IDbTransaction dbTransaction = null)
        {
            if (dbConnection != null && dbTransaction == null)
            {
                return await dbConnection.ExecuteAsync(sql, sqlParams, commandTimeout: _dapperTimeout).ConfigureAwait(false);
            }
            else if (dbConnection != null && dbTransaction != null)
            {
                return await dbConnection.ExecuteAsync(sql, sqlParams, dbTransaction, commandTimeout: _dapperTimeout).ConfigureAwait(false);
            }
            else
            {
                using (IDbConnection dbConn = CreateDbConnection())
                {
                    return await dbConn.ExecuteAsync(sql, sqlParams, commandTimeout: _dapperTimeout).ConfigureAwait(false);
                }
            }
        }
    }
}
