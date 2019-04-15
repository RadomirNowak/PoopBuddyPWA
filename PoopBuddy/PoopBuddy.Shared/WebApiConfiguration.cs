using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PoopBuddy.Shared
{
    public abstract class ConfigurationBase
    {
        protected ConfigurationBase(IConfiguration configuration, string prefix)
        {
            this.configuration = configuration;
        }

        private IConfiguration configuration { get; }

        protected object GetValue(string key)
        {
            try
            {
                return configuration[key];
            }
            catch (KeyNotFoundException ex)
            {
                return null;
            }
        }

        protected string GetString(string key)
        {
            return GetValue(key).ToString();
        }

        protected string GetStringOrDefault(string key, string defaultValue)
        {
            var value = GetValue(key);

            return value == null ? defaultValue : value.ToString();
        }
    }

    public interface IWebApiConfiguration
    {
        string ConnectionString { get; }
    }

    internal class WebApiConfiguration : ConfigurationBase, IWebApiConfiguration
    {
        public string ConnectionString => GetStringOrDefault("ConnectionString", @"Server=(localdb)\mssqllocaldb;Database=PoopBuddyDevDb;Trusted_Connection=True;ConnectRetryCount=0");

        public WebApiConfiguration(IConfiguration configuration) : base(configuration, "WebApi")
        {
        }
    }
}
