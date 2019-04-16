using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Web.LocalDTO
{
    public class RecordPoopingRequest
    {
        public string AuthorName { get; set; }
        public double DurationInMs { get; set; }
        public decimal WagePerHour { get; set; }
    }
}
