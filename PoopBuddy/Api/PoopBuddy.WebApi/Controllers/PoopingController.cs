using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.WebApi.DTO;

namespace PoopBuddy.WebApi.Controllers
{
    [Route("[controller]")]
    public class PoopingController : Controller
    {
        [Route("[action]")]
        [ProducesResponseType(typeof(GetAllPoopingsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(new GetAllPoopingsResponse());
        }
    }
}