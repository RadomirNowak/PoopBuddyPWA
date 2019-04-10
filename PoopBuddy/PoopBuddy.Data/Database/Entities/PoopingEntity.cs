using System;

namespace PoopBuddy.Data.Database.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ExternalId { get; set; }
    }

    public class PoopingEntity : BaseEntity
    {
        public string Author { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal WagePerHour { get; set; }
    }
}
