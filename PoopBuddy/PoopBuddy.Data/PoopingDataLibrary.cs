using Microsoft.Extensions.DependencyInjection;

namespace PoopBuddy.Data
{
    public static class PoopingDataLibrary
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IPoopingLogic, PoopingLogic>();
        }
    }
}
