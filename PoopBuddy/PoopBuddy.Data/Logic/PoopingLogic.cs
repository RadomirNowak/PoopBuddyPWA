using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using PoopBuddy.Data.Database.Entities;
using PoopBuddy.Data.Database.Repositories;
using PoopBuddy.Shared.DTO.Pooping;
using ILogger = Serilog.ILogger;

namespace PoopBuddy.Data.Logic
{
    public interface IPoopingLogic
    {
        [NotNull] GetAllPoopingsResponse GetAll();
        Guid Add([NotNull] AddPoopingRequest request);
    }

    public class PoopingLogic : IPoopingLogic
    {
        private readonly IPoopingRepository poopingRepository;

        public PoopingLogic(IPoopingRepository poopingRepository, ILogger<PoopingLogic> logger)
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

        public Guid Add(AddPoopingRequest request)
        {
            var poopingEntity = new PoopingEntity
            {
                Author = request.AuthorName,
                WagePerHour = request.WagePerHour,
                Duration = request.Duration,
                ExternalId = Guid.NewGuid()
            };

            return poopingRepository.Add(poopingEntity);
        }
    }
}