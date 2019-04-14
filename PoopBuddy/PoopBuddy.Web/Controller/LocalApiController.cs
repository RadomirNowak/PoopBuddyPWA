
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Shared.DTO;

namespace PoopBuddy.Web.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LocalApiController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("[action]")]
        public IActionResult GetAllPoopings()
        {
            return Ok(new GetAllPoopingsResponse
            {
                PoopingList = new List<PoopingDTO>
                {
                    new PoopingDTO
                    {
                        AuthorName = "Test John",
                        Duration = TimeSpan.FromSeconds(6),
                        WagePerHour = 55,
                        ExternalId = Guid.NewGuid()
                    }
                }
            });
        }
    }
}
