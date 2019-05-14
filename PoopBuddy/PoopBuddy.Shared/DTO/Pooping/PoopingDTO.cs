using System;

namespace PoopBuddy.Shared.DTO.Pooping
{
    public class PoopingDTO
    {
        public Guid ExternalId { get; set; }

        public string AuthorName { get; set; }

        public TimeSpan Duration { get; set; }

        public double DurationInMs => Duration.TotalMilliseconds;

        public decimal WagePerHour { get; set; }
    }
}
