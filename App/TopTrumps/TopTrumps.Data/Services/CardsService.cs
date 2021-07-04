using System;

namespace TopTrumps.Data.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using DTOs;
    using Helpers;
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

        public async Task<Card> GetCard(int id)
        {
            return await _repo.QuerySingleAsync<Card>(
                _helper.GetCardQuery(id),
                new CancellationToken(),
                new { id });
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _repo.QueryAsync<Card>(
                _helper.GetAllCardsQuery(), 
                new CancellationToken());
        }

        public async Task<IEnumerable<PlayersCard>> GetPlayersCollection(string email)
        {
            throw new Exception("JACK HASN'T FUCKING DONE THIS YET!!!!!!!");
        }

        public async Task<int> CreateNewCard(Card card)
        {
            return await _repo.QuerySingleAsync<int>(
                _helper.CreateNewCardSql(),
                new CancellationToken(),
                card);
        }

        public async Task<Card> UpdateCard(Card card)
        {
            await _repo.ExecuteAsync(
                _helper.GetUpdateCardSql(), 
                new CancellationToken(), 
                card);

            return card;
        }
    }
}
