using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PoopBuddy.Web.ApiClient;
using PoopBuddy.Web.Configuration;

namespace PoopBuddy.Web
{
    public static class PoopingWebAppLibrary
    {
        public static void AddWebAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IWebAppConfiguration, WebAppConfiguration>();
            services.AddSingleton<IPoopingApiClient, PoopingApiClient>();
            services.AddSingleton<INotificationApiClient, NotificationApiClient>();
        }
    }
}
