using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Data.Entity;
using PoopBuddy.Data.Repository;

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
        public ActionResult<IEnumerable<string>> GetAll()
        {
            var poopings = poopingRepository.GetAll();
            var poopingTitles = poopings.Select(p => p.PoopingTitle).ToArray();

            return poopingTitles;
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