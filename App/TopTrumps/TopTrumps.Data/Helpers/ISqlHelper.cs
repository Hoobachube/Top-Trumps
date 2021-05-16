namespace TopTrumps.Data.Helpers
{
    public interface ISqlHelper
    {
        string GetCardQuery(int id);

        string GetAllCardsQuery();

        string GetCollectionSql(string email);

        string CreateNewCardSql();

        string GetUpdateCardSql();
    }
}
