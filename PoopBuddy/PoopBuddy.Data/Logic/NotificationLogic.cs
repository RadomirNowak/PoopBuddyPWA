using System;
using PoopBuddy.Data.Database.Entities;
using PoopBuddy.Data.Database.Repositories;
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

        public NotificationLogic(ISubscribersRepository repository)
        {
            this.repository = repository;
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
            var subscribers = repository.GetAll();

            // todo WebPush logic
        }
    }
}
