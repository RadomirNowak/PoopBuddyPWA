using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoopBuddy.Shared.DTO.Notification;
using PoopBuddy.Shared.Http;
using PoopBuddy.Web.Configuration;

namespace PoopBuddy.Web.ApiClient
{
    public interface INotificationApiClient
    {
        Task AddSubscriber(AddSubscriberRequest request);
        Task SendNotification(SendNotificationRequest request);
    }

    internal class NotificationApiClient : INotificationApiClient
    {
        private readonly IWebAppConfiguration configuration;

        public NotificationApiClient(IWebAppConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task AddSubscriber(AddSubscriberRequest request)
        {
            var address = configuration.NotificationApiAddress + "AddSubscriber";
            await HttpClientHelper.PostAsync<AddSubscriberRequest, object>(request, address);
        }

        public async Task SendNotification(SendNotificationRequest request)
        {
            var address = configuration.NotificationApiAddress + "SendNotification";
            await HttpClientHelper.PostAsync<SendNotificationRequest, object>(request, address);
        }
    }
}
