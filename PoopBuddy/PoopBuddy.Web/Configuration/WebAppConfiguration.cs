using Microsoft.Extensions.Configuration;
using PoopBuddy.Shared;

namespace PoopBuddy.Web.Configuration
{
    internal interface IWebAppConfiguration
    {
        string PoopingApiAddress { get; }
    }

    internal class WebAppConfiguration : ConfigurationBase, IWebAppConfiguration
    {
        public WebAppConfiguration(IConfiguration configuration) : base(configuration, "WebApp")
        {
        }

        public string PoopingApiAddress => this.GetStringOrDefault("PoopingApiAddress", "https://localhost:44317/pooping/");
    }
}
