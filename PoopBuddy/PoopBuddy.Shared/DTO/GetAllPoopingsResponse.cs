using System.Collections.Generic;

namespace PoopBuddy.Shared.DTO
{
    public class GetAllPoopingsResponse
    {
        public IList<PoopingDTO> PoopingList { get; set; }
    }
}
