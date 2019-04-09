using System.Collections.Generic;
using PoopBuddy.Data.Repositories;
using PoopBuddy.Shared.DTO;

namespace PoopBuddy.Data
{
    public interface IPoopingLogic
    {
        GetAllPoopingsResponse GetAll();
    }

    public class PoopingLogic : IPoopingLogic
    {
        private readonly IPoopingRepository poopingRepository;

        public PoopingLogic(IPoopingRepository poopingRepository)
        {
            this.poopingRepository = poopingRepository;
        }

        public GetAllPoopingsResponse GetAll()
        {
            var poopings = poopingRepository.GetAll();
            var response = new GetAllPoopingsResponse
            {
                PoopingList = new List<PoopingDTO>()
            };
            foreach (var pooping in poopings)
                response.PoopingList.Add(new PoopingDTO
                {
                    AuthorName = pooping.Author,
                    Duration = pooping.Duration,
                    ExternalId = pooping.ExternalId,
                    WagePerHour = pooping.WagePerHour
                });

            return response;
        }
    }
}