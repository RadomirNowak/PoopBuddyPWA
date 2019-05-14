using System;

namespace PoopBuddy.Data.Database.Entities
{
    public class SubscriberEntity : BaseEntity
    {
        public string Endpoint { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public string P256Dh { get; set; }

        public string Auth { get; set; }
    }
}
