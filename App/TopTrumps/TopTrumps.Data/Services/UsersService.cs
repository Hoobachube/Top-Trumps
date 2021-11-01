using System;
using TopTrumps.Data.Helpers;
using TopTrumps.Data.Repository;

namespace TopTrumps.Data.Services
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using DTOs;
    using Microsoft.AspNetCore.Identity;

    public class UsersService :
        IUserStore<User>,
        IUserEmailStore<User>,
        IUserPhoneNumberStore<User>,
        IUserTwoFactorStore<User>,
        IUserPasswordStore<User>,
        IUserRoleStore<User>,
        IUsersService

    {
        private readonly IRepository _repo;
        private readonly ISqlHelper _helper;
        private readonly IRoleStore<Role> _rolesStore;

        public UsersService(IRepository repo, ISqlHelper helper, IRoleStore<Role> rolesStore)
        {
            _repo = repo;
            _helper = helper;
            _rolesStore = rolesStore;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            user.Id = await _repo.QuerySingleAsync<int>(
                _helper.GetCreateUsersSql(),
                cancellationToken,
                user);

            await AddToRoleAsync(user, "Player", cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            await _repo.ExecuteAsync(
                $"DELETE FROM [Users] WHERE [Id] = @{nameof(User.Id)}",
                cancellationToken,
                user);

            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _repo.QuerySingleOrDefaultAsync<User>(
                $@"SELECT * FROM [Users] WHERE [Id] = @{nameof(userId)}",
                cancellationToken,
                new { userId });
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _repo.QuerySingleOrDefaultAsync<User>(
                $@"SELECT * FROM [Users] WHERE [NormalizedUserName] = @{nameof(normalizedUserName)}",
                cancellationToken,
                new { normalizedUserName });
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var sql = $@"UPDATE [Users] SET
                [UserName] = @{nameof(User.UserName)},
                [NormalizedUserName] = @{nameof(User.NormalizedUserName)},
                [Email] = @{nameof(User.Email)},
                [NormalizedEmail] = @{nameof(User.NormalizedEmail)},
                [EmailConfirmed] = @{nameof(User.EmailConfirmed)},
                [PasswordHash] = @{nameof(User.PasswordHash)},
                [PhoneNumber] = @{nameof(User.PhoneNumber)},
                [PhoneNumberConfirmed] = @{nameof(User.PhoneNumberConfirmed)},
                [TwoFactorEnabled] = @{nameof(User.TwoFactorEnabled)}
                WHERE [Id] = @{nameof(User.Id)}";

            await _repo.ExecuteAsync(sql, cancellationToken, user);

            return IdentityResult.Success;
        }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await _repo.QuerySingleOrDefaultAsync<User>(
                $@"SELECT * FROM [Users] WHERE [NormalizedEmail] = @{nameof(normalizedEmail)}",
                cancellationToken,
                new { normalizedEmail });
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }

        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var role = await _rolesStore.FindByNameAsync(roleName, cancellationToken);
            if (role == null)
            {
                throw new Exception($"Role does not exist {roleName}");
            }

            await _repo.ExecuteAsync(
                _helper.GetAddUserToRoleSql(role),
                cancellationToken,
                new { userId = user.Id, role.Id });
        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var roleId = await _repo.ExecuteScalarAsync<int?>(
                "SELECT [Id] FROM [Roles] WHERE [NormalizedName] = @normalizedName",
                cancellationToken,
                new { normalizedName = roleName.ToUpper() });

            if (!roleId.HasValue)
            {
                await _repo.ExecuteAsync(
                    $"DELETE FROM [UsersVsRoles] WHERE [UserId] = @userId AND [RoleId] = @{nameof(roleId)}",
                    cancellationToken,
                    new { userId = user.Id, roleId });
            }
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            return (await _repo.QueryAsync<string>(
                $@"SELECT r.[Name] 
                    FROM [Roles] r 
                    INNER JOIN [UsersVsRoles] ur ON ur.[RoleId] = r.Id 
                    WHERE ur.UserId = @userId",
                cancellationToken,
                new { userId = user.Id })).ToList();
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
                var roleId = await _repo.ExecuteScalarAsync<int?>(
                    "SELECT [Id] FROM [Roles] WHERE [NormalizedName] = @normalizedName", 
                    cancellationToken,
                    new { normalizedName = roleName.ToUpper() });

                if (roleId == default(int))
                {
                    return false;
                }

                var matchingRoles = await _repo.ExecuteScalarAsync<int>(
                    $"SELECT COUNT(*) FROM [UsersVsRoles] WHERE [UserId] = @userId AND [RoleId] = @{nameof(roleId)}",
                    cancellationToken,
                    new { userId = user.Id, roleId });

                return matchingRoles > 0;
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return (await _repo.QueryAsync<User>(
                $@"SELECT u.* 
                    FROM [Users] u 
                    INNER JOIN [UsersVsRoles] ur ON ur.[UserId] = u.[Id] 
                    INNER JOIN [Roles] r ON r.[Id] = ur.[RoleId] 
                    WHERE r.[NormalizedName] = @normalizedName",
                cancellationToken,
                new { normalizedName = roleName.ToUpper() })).ToList();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repo.QueryAsync<User>(
                _helper.GetAllCardsQuery(),
                new CancellationToken());
        }

        Task<User> IUsersService.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
