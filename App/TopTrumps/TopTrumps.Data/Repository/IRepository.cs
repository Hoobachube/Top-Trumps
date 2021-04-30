using System.Threading;

namespace TopTrumps.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository 
    { 
        Task<IEnumerable<TDto>> QueryAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null);

        Task<TDto> QuerySingleOrDefaultAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null);

        Task<TDto> QuerySingleAsync<TDto>(string sql, CancellationToken cancellationToken, object param = null);

        Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object param = null);

        Task<T> ExecuteScalarAsync<T>(string sql, CancellationToken cancellationToken, object param = null);
    }
}
