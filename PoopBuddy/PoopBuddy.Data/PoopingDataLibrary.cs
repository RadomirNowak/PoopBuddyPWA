using Microsoft.Extensions.DependencyInjection;
using PoopBuddy.Data.Database.Context;
using PoopBuddy.Data.Database.Repositories;
using PoopBuddy.Data.Logic;

namespace PoopBuddy.Data
{
    public static class PoopingDataLibrary
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            ConfigureDb(services);
            services.AddSingleton<IPoopingLogic, PoopingLogic>();
            services.AddSingleton<IPoopingRepository, PoopingRepository>();
            services.AddSingleton<INotificationLogic, NotificationLogic>();
            services.AddSingleton<ISubscribersRepository, SubscribersRepository>();

        }

        private static void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<PoopingContext>(ServiceLifetime.Singleton);
        }
    }
}
