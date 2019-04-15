using System;
using System.Threading.Tasks;
using PoopBuddy.Shared.DTO;
using PoopBuddy.Shared.Http;
using PoopBuddy.Web.Configuration;

namespace PoopBuddy.Web.ApiClient
{
    public interface IPoopingApiClient
    {
        Task<GetAllPoopingsResponse> GetAllPoopings();
    }

    internal class PoopingApiClient : IPoopingApiClient
    {
        private readonly IWebAppConfiguration webAppConfiguration;

        public PoopingApiClient(IWebAppConfiguration webAppConfiguration)
        {
            this.webAppConfiguration = webAppConfiguration;
        }

        public async Task<GetAllPoopingsResponse> GetAllPoopings()
        {
            var address = webAppConfiguration.PoopingApiAddress + "GetAll";
            return await HttpClientHelper.GetAsync<GetAllPoopingsResponse>(address);
        }
    }
}
