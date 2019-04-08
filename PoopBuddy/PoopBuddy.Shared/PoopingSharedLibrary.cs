using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PoopBuddy.Shared
{
    public static class PoopingSharedLibrary
    {
        public static void AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<IWebApiConfiguration, WebApiConfiguration>();
        }
    }
}
