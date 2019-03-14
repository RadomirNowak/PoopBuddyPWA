using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Data.Entity;
using PoopBuddy.Data.Repository;
using PoopBuddy.WebApi.Model;

namespace PoopBuddy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoopingsController : ControllerBase
    {
        private readonly IPoopingRepository poopingRepository;

        public PoopingsController(IPoopingRepository poopingRepository)
        {
            this.poopingRepository = poopingRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<GetAllPoopingsResponse> GetAll()
        {
            var poopings = poopingRepository.GetAll();
            var poopingDtoList = poopings.Select(pooping => new PoopingDto
                {
                    PoopingTitle = pooping.PoopingTitle,
                    Duration = pooping.Duration,
                    Earning = pooping.Earning
                })
                .ToList();

            var getAllPoopingsResponse = new GetAllPoopingsResponse
            {
                Poopings = poopingDtoList
            };
            return getAllPoopingsResponse;
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult<bool> AddRandomPooping()
        {
            var randomPooping = new PoopingEntity
            {
                Id = new Guid(),
                Duration = new TimeSpan(10),
                Earning = 10,
                PoopingTitle = "Random title"
            };

            poopingRepository.Add(randomPooping);

            return true;
        }
    }
}