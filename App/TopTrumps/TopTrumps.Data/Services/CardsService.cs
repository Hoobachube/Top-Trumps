using System.Threading;
using TopTrumps.Data.Helpers;

namespace TopTrumps.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;
    using Repository;

    public class CardsService : ICardsService
    {
        private readonly IRepository _repo;
        private readonly ISqlHelper _helper;

        public CardsService(IRepository repo, ISqlHelper helper)
        {
            _repo = repo;
            _helper = helper;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            var sql = _helper.GetAllCardsQuery();

            return await _repo.QueryAsync<Card>(sql, new CancellationToken());
        }

        public async Task<IEnumerable<PlayersCard>> GetPlayersCollection(string email)
        {
            var sql = _helper.GetCollectionSql(email);

            return await _repo.QueryAsync<PlayersCard>(sql, new CancellationToken(), new { email });
        }
    }
}
