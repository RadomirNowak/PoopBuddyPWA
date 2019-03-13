using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Data.Entity
{
    public class PoopingEntity
    {
        public Guid Id { get; set; }

        public string PoopingTitle { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Earning { get; set; }
    }
}
