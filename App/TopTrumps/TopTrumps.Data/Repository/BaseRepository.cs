using System.Threading;

namespace TopTrumps.Data.Repository
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using Microsoft.Extensions.Configuration;

    public class BaseRepository : IRepository
    {
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("topTrumps");
        }

        public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object param = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using var conn = new SqlConnection(_connectionString);

            await conn.OpenAsync(cancellationToken);

            return await conn.ExecuteAsync(sql, param);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, CancellationToken cancellationToken, object param = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using var conn = new SqlConnection(_connectionString);

            await conn.OpenAsync(cancellationToken);

            return await conn.ExecuteScalarAsync<T>(sql, param);
        }

        public async Task<IEnumerable<TDto>> QueryAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using var conn = new SqlConnection(_connectionString);

            await conn.OpenAsync(cancellationToken);

            return await conn.QueryAsync<TDto>(sql, param);
        }

        public async Task<TDto> QuerySingleAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using var conn = new SqlConnection(_connectionString);

            await conn.OpenAsync(cancellationToken);

            return await conn.QuerySingleAsync<TDto>(sql, param);
        }

        public async Task<TDto> QuerySingleOrDefaultAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using var conn = new SqlConnection(_connectionString);

            await conn.OpenAsync(cancellationToken);

            return await conn.QuerySingleOrDefaultAsync<TDto>(sql, param);
        }
    }
}
