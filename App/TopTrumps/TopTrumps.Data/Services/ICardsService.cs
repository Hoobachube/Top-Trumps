namespace TopTrumps.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;

    public interface ICardsService
    {
        Task<Card> GetCard(int id);

        Task<IEnumerable<Card>> GetAllCards();

        Task<IEnumerable<PlayersCard>> GetPlayersCollection(string email);

        Task<int> CreateNewCard(Card card);

        Task<Card> UpdateCard(Card card);
    }
}
