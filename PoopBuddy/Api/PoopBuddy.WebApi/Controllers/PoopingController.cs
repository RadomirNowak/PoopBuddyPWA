using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PoopingController> logger;

        public PoopingController(IPoopingLogic poopingLogic, ILogger<PoopingController> logger)
        {
            this.poopingLogic = poopingLogic;
            this.logger = logger;
        }

        [Route("[action]")]
        [ProducesResponseType(typeof(GetAllPoopingsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            LogMethod();
            var result = poopingLogic.GetAll();
            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPooping(AddPoopingRequest request)
        {
            LogMethod();
            poopingLogic.Add(request);
            return Ok();
        }

        private void LogMethod([CallerMemberName] string action = "")
        {
            logger.LogDebug(action);
        }
    }
}