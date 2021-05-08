namespace TopTrumps.Data.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        public string GetAllCardsQuery()
        {
            return @"SELECT * FROM [Cards]";
        }

        public string GetCollectionSql(string email)
        {
            return $@"SELECT 
	                    C.[Id],
	                    C.[Name],
	                    C.[Type],
	                    C.[ABV],
	                    C.[Accessibility],
	                    C.[Reputation],
	                    C.[Popularity],
	                    C.[Description],
	                    CT.[InDeck]
                    FROM [dbo].[Collection] CT
                    JOIN [dbo].[Cards] C ON CT.CardId = C.Id
                    JOIN [dbo].[Users] U ON CT.UserId = U.Id
                    WHERE U.[Email] = @{nameof(email)}";
        }
    }
}
