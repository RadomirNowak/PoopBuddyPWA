using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Data;
using PoopBuddy.Data.Logic;
using PoopBuddy.Shared.DTO.Pooping;

namespace PoopBuddy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoopingController : Controller
    {
        private readonly IPoopingLogic poopingLogic;

        public PoopingController(IPoopingLogic poopingLogic)
        {
            this.poopingLogic = poopingLogic;
        }

        [Route("[action]")]
        [ProducesResponseType(typeof(GetAllPoopingsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = poopingLogic.GetAll();
            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPooping(AddPoopingRequest request)
        {
            poopingLogic.Add(request);
            return Ok();
        }
    }
}