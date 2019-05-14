using System;

namespace PoopBuddy.Shared.DTO.Notification
{
    public class AddSubscriberRequest
    {
        public string Endpoint { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public Keys Keys { get; set; }
    }

    public class Keys
    {
        public string P256Dh { get; set; }
        public string Auth { get; set; }
    }
}
