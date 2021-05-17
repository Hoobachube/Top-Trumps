using TopTrumps.Data.Repository;

namespace TopTrumps.Data.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    using DTOs;
    using Microsoft.AspNetCore.Identity;

    public class RolesService : IRoleStore<Role>
    {
        private readonly IRepository _repo;

        public RolesService(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            await _repo.QuerySingleAsync<int>(
                $@"INSERT INTO [Roles] ([Name], [NormalizedName]) 
                   VALUES (@{nameof(Role.Name)}, @{nameof(Role.NormalizedName)}); 
                   SELECT CAST(SCOPE_IDENTITY() as int)",
                cancellationToken,
                role);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            await _repo.ExecuteAsync(
                $@"UPDATE [Roles] SET [Name] = @{nameof(Role.Name)}, [NormalizedName] = @{nameof(Role.NormalizedName)} WHERE [Id] = @{nameof(Role.Id)}",
                cancellationToken,
                role);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            await _repo.ExecuteAsync(
                $"DELETE FROM [Roles] WHERE [Id] = @{nameof(Role.Id)}",
                cancellationToken,
                role);

            return IdentityResult.Success;
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await _repo.QuerySingleOrDefaultAsync<Role>(
                $@"SELECT * FROM [Roles] WHERE [Id] = @{nameof(roleId)}",
                cancellationToken,
                new { roleId });
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _repo.QuerySingleOrDefaultAsync<Role>(
                $@"SELECT * FROM [Roles] WHERE [NormalizedName] = @{nameof(normalizedRoleName)}",
                cancellationToken,
                new { normalizedRoleName });
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}
