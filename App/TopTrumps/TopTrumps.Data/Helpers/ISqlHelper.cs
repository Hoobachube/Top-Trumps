namespace TopTrumps.Data.Helpers
{
    public interface ISqlHelper
    {
        string GetAllCardsQuery();

        string GetCollectionSql(string email);
    }
}
