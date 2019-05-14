using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using PoopBuddy.Data.Database.Entities;
using PoopBuddy.Data.Database.Repositories;
using PoopBuddy.Shared;
using PoopBuddy.Shared.DTO.Notification;

namespace PoopBuddy.Data.Logic
{
    public interface INotificationLogic
    {
        void AddSubscriber(AddSubscriberRequest request);
        void SendNotification(SendNotificationRequest request);
    }

    internal class NotificationLogic : INotificationLogic
    {
        private readonly ISubscribersRepository repository;
        private readonly ILogger<NotificationLogic> logger;

        public NotificationLogic(ISubscribersRepository repository, ILogger<NotificationLogic> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public void AddSubscriber(AddSubscriberRequest request)
        {
            repository.Add(new SubscriberEntity
            {
                ExternalId = Guid.NewGuid(),
                Auth = request.Keys.Auth,
                Endpoint = request.Endpoint,
                ExpirationTime = request.ExpirationTime,
                P256Dh = request.Keys.P256Dh
            });
        }

        public void SendNotification(SendNotificationRequest request)
        {
            logger.LogDebug("Sending notification to all subscribers");
            var subscribers = repository.GetAll();
            
            logger.LogDebug($"Sending notification to {subscribers.Count()} subscribers");
            foreach (var subscriber in subscribers)
            {
                logger.LogDebug($"Sending notification to {JsonSerializerHelper.Serialize(subscriber)}");
                WebPushHelper.SendNotification(request.Message, subscriber.Endpoint, subscriber.P256Dh, subscriber.Auth);
            }
        }
    }
}
