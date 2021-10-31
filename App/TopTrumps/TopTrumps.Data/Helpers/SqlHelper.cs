using TopTrumps.Data.DTOs;

namespace TopTrumps.Data.Helpers
{
    using DTOs;

    public class SqlHelper : ISqlHelper
    {
        public string GetCardQuery(int id)
        {
            return $@"SELECT * FROM [Cards] WHERE [Id] = @{nameof(id)}";
        }

        public string GetAllUsersQuery()
        {
            return @"SELECT * FROM [Cards]";
        }

        public string GetAddUserToRoleSql(Role role)
        {
            return $@"IF NOT EXISTS(
                            SELECT 1 FROM [UsersVsRoles] 
                            WHERE [UserId] = @userId AND [RoleId] = @{nameof(role.Id)}
                        ) 
                        INSERT INTO [UsersVsRoles]([UserId], [RoleId]) VALUES(@userId, @{nameof(role.Id)})";
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
                        C.[ImageUrl],
	                    CT.[InDeck]
                    FROM [dbo].[Collection] CT
                    JOIN [dbo].[Cards] C ON CT.CardId = C.Id
                    JOIN [dbo].[Users] U ON CT.UserId = U.Id
                    WHERE U.[Email] = @{nameof(email)}";
        }

        public string GetCreateUsersSql()
        {
            return $@"INSERT INTO [Users] 
                            ([UserName], 
                            [NormalizedUserName], 
                            [Email], 
                            [NormalizedEmail], 
                            [EmailConfirmed], 
                            [PasswordHash], 
                            [PhoneNumber], 
                            [PhoneNumberConfirmed], 
                            [TwoFactorEnabled])
                        VALUES 
                            (@{nameof(User.UserName)}, 
                            @{nameof(User.NormalizedUserName)}, 
                            @{nameof(User.Email)},
                            @{nameof(User.NormalizedEmail)}, 
                            @{nameof(User.EmailConfirmed)}, 
                            @{nameof(User.PasswordHash)},
                            @{nameof(User.PhoneNumber)}, 
                            @{nameof(User.PhoneNumberConfirmed)}, 
                            @{nameof(User.TwoFactorEnabled)});
                        SELECT CAST(SCOPE_IDENTITY() as int)";
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
                            ,[Description]
                            ,[ImageUrl])
                        VALUES 
                            (@{nameof(Card.Name)}, 
                            @{nameof(Card.Type)}, 
                            @{nameof(Card.ABV)},
                            @{nameof(Card.Accessibility)}, 
                            @{nameof(Card.Reputation)}, 
                            @{nameof(Card.Popularity)},
                            @{nameof(Card.Description)},
                            @{nameof(Card.ImageUrl)});
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
                [Description] = @{nameof(Card.Description)},
                [ImageUrl] = @{nameof(Card.ImageUrl)}
                WHERE [Id] = @{nameof(Card.Id)}";
        }


        public string GetAllUserssql()
        {
            return @"SELECT * FROM [Users]";
        }

        public string GetAllUsersSql()
        {
            throw new System.NotImplementedException();
        }
    }
}
