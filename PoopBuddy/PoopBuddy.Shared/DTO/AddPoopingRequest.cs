using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Shared.DTO
{
    public class AddPoopingRequest
    {
        public string AuthorName { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal WagePerHour { get; set; }
    }
}
