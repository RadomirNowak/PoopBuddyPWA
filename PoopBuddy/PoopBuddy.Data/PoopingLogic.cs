using System;
using System.Collections.Generic;
using PoopBuddy.Data.Entities;
using PoopBuddy.Data.Repositories;
using PoopBuddy.Shared.DTO;

namespace PoopBuddy.Data
{
    public interface IPoopingLogic
    {
        GetAllPoopingsResponse GetAll();
        void Add(AddPoopingRequest request);
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

        public void Add(AddPoopingRequest request)
        {
            var poopingEntity = new PoopingEntity
            {
                Author = request.AuthorName,
                WagePerHour = request.WagePerHour,
                Duration = request.Duration,
                ExternalId = new Guid()
            };

            poopingRepository.Add(poopingEntity);
        }
    }
}