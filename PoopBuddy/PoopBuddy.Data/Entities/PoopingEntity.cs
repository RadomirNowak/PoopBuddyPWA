using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Data.Entities
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
