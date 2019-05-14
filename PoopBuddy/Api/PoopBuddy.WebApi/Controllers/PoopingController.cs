using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
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
            LogMethod(Request.Body);
            var result = poopingLogic.GetAll();
            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddPooping(AddPoopingRequest request)
        {
            LogMethod(Request.Body);
            poopingLogic.Add(request);
            return Ok();
        }

        private void LogMethod(Stream body, [CallerMemberName] string action = "")
        {
            logger.LogDebug(action);
            try
            {
                body.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(body, Encoding.UTF8))
                {
                    logger.LogDebug(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }
    }
}