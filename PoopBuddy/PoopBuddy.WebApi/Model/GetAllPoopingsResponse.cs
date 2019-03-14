using System.Collections.Generic;

namespace PoopBuddy.WebApi.Model
{
    public class GetAllPoopingsResponse
    {
        public IEnumerable<PoopingDto> Poopings { get; set; }
    }
}

