using System.Collections.Generic;

namespace PoopBuddy.Shared.DTO.Pooping
{
    public class GetAllPoopingsResponse
    {
        public IList<PoopingDTO> PoopingList { get; set; }
    }
}
