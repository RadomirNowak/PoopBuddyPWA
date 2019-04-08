using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.WebApi.DTO
{
    public class GetAllPoopingsResponse
    {
        public IList<object> PoopingsList { get; set; }
    }
}
