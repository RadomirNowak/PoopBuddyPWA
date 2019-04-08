using Microsoft.Extensions.DependencyInjection;
using PoopBuddy.Data.Context;

namespace PoopBuddy.Data
{
    public static class PoopingDataLibrary
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IPoopingLogic, PoopingLogic>();
            ConfigureDb(services);
        }

        private static void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<PoopingContext>();
        }
    }
}
