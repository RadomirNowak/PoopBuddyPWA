using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Shared.DTO
{
    public class PoopingDTO
    {
        public Guid ExternalId { get; set; }

        public string AuthorName { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal WagePerHour { get; set; }
    }
}
