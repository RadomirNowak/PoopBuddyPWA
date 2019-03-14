using System;

namespace PoopBuddy.WebApi.Model
{
    public class PoopingDto
    {
        public string PoopingTitle { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Earning { get; set; }
    }
}
