using TopTrumps.Data.DTOs;

namespace TopTrumps.Data.Helpers
{
    public class SqlHelper : ISqlHelper
    {
        public string GetAllCardsQuery()
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
    }
}
