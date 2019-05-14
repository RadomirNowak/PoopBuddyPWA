using System;

namespace PoopBuddy.Shared.DTO.Pooping
{
    public class AddPoopingRequest
    {
        public string AuthorName { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal WagePerHour { get; set; }
    }
}
