using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoopBuddy.Shared.DTO
{
    public class PoopingDTO
    {
        public Guid ExternalId { get; set; }

        public string AuthorName { get; set; }

        [JsonIgnore] // we don't want the TimeSpan to be serialized. It's hard to parse it later on, thats why DurationInMs field exists in this object
        public TimeSpan Duration { get; set; }

        public double DurationInMs => Duration.TotalMilliseconds;

        public decimal WagePerHour { get; set; }
    }
}
