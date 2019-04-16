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
        Task AddPooping(AddPoopingRequest request);
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

        public async Task AddPooping(AddPoopingRequest request)
        {
            var address = webAppConfiguration.PoopingApiAddress + "AddPooping";
            await HttpClientHelper.PostAsync<AddPoopingRequest, object>(request, address);
        }
    }
}
