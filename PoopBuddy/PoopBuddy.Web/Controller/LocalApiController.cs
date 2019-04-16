using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Shared.DTO;
using PoopBuddy.Web.ApiClient;
using PoopBuddy.Web.LocalDTO;

namespace PoopBuddy.Web.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LocalApiController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPoopingApiClient poopingApiClient;

        public LocalApiController(IPoopingApiClient poopingApiClient)
        {
            this.poopingApiClient = poopingApiClient;
        }

        [Route("[action]")]
        public async Task<IActionResult> GetAllPoopings()
        {
            var poopings = poopingApiClient.GetAllPoopings();

            return Ok(await poopings);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> RecordPooping(RecordPoopingRequest request)
        {
            var addPoopingRequest = new AddPoopingRequest
            {
                AuthorName = request.AuthorName,
                WagePerHour = request.WagePerHour,
                Duration = TimeSpan.FromMilliseconds(request.DurationInMs)
            };
            await poopingApiClient.AddPooping(addPoopingRequest);
            return Ok();
        }
    }
}
