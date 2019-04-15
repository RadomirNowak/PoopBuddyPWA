using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Web.ApiClient;

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

            //return Ok(new GetAllPoopingsResponse
            //{
            //    PoopingList = new List<PoopingDTO>
            //    {
            //        new PoopingDTO
            //        {
            //            AuthorName = "Test John",
            //            Duration = TimeSpan.FromSeconds(6),
            //            WagePerHour = 55,
            //            ExternalId = Guid.NewGuid()
            //        },
            //        new PoopingDTO
            //        {
            //            AuthorName = "Jane",
            //            Duration = TimeSpan.FromSeconds(12),
            //            WagePerHour = 10,
            //            ExternalId = Guid.NewGuid()
            //        },
            //        new PoopingDTO
            //        {
            //            AuthorName = "Janice",
            //            Duration = TimeSpan.FromSeconds(64),
            //            WagePerHour = 66,
            //            ExternalId = Guid.NewGuid()
            //        },
            //    }
            //});
        }
    }
}
