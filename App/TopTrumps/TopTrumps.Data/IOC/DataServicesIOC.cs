using TopTrumps.Data.Helpers;

namespace TopTrumps.Data.IOC
{
    using DTOs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Repository;
    using Services;

    public class DataServicesIoc
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddTransient<IRepository, BaseRepository>();
            services.AddTransient<ICardsService, CardsService>();
            services.AddTransient<IUserStore<User>, UsersService>();
            services.AddTransient<IRoleStore<Role>, RolesService>();
            services.AddTransient<ISqlHelper, SqlHelper>();
        }
    }
}
