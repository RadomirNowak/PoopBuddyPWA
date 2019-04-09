using Microsoft.Extensions.DependencyInjection;
using PoopBuddy.Data.Context;
using PoopBuddy.Data.Repositories;

namespace PoopBuddy.Data
{
    public static class PoopingDataLibrary
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            ConfigureDb(services);
            services.AddSingleton<IPoopingLogic, PoopingLogic>();
            services.AddSingleton<IPoopingRepository, PoopingRepository>();

        }

        private static void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<PoopingContext>(ServiceLifetime.Singleton);
        }
    }
}
