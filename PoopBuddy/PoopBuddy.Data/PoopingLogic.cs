using PoopBuddy.Shared.DTO;

namespace PoopBuddy.Data
{
    public interface IPoopingLogic
    {
        GetAllPoopingsResponse GetAll();
    }

    public class PoopingLogic : IPoopingLogic
    {
        public GetAllPoopingsResponse GetAll()
        {
            return new GetAllPoopingsResponse();
        }
    }
}
