namespace TopTrumps.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;

    public interface IUsersService
    {
        Task<User> GetUser(int id);

        Task<IEnumerable<User>> GetUsers();
    }
}
