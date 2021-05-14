using TopTrumps.Data.DTOs;

namespace TopTrumps.Data.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        public string GetCardQuery(int id)
        {
            return $@"SELECT * FROM [Cards] WHERE [Id] = @{nameof(id)}";
        }

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

        public string CreateNewCardSql()
        {
            return $@"INSERT INTO [dbo].[Cards]
                            ([Name]
                            ,[Type]
                            ,[ABV]
                            ,[Accessibility]
                            ,[Reputation]
                            ,[Popularity]
                            ,[Description])
                        VALUES 
                            (@{nameof(Card.Name)}, 
                            @{nameof(Card.Type)}, 
                            @{nameof(Card.ABV)},
                            @{nameof(Card.Accessibility)}, 
                            @{nameof(Card.Reputation)}, 
                            @{nameof(Card.Popularity)},
                            @{nameof(Card.Description)});
                        SELECT CAST(SCOPE_IDENTITY() as int)";
        }

        public string GetUpdateCardSql()
        {
            return $@"UPDATE [dbo].[Cards] SET
                [Name] = @{nameof(Card.Name)},
                [Type] = @{nameof(Card.Type)},
                [ABV] = @{nameof(Card.ABV)},
                [Accessibility] = @{nameof(Card.Accessibility)},
                [Reputation] = @{nameof(Card.Reputation)},
                [Popularity] = @{nameof(Card.Popularity)},
                [Description] = @{nameof(Card.Description)}
                WHERE [Id] = @{nameof(Card.Id)}";
        }
    }
}
