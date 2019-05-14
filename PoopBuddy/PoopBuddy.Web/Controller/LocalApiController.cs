using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using PoopBuddy.Shared.DTO.Notification;
using PoopBuddy.Shared.DTO.Pooping;
using PoopBuddy.Web.ApiClient;
using PoopBuddy.Web.LocalDTO;

namespace PoopBuddy.Web.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LocalApiController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPoopingApiClient poopingApiClient;
        private readonly INotificationApiClient notificationApiClient;
        private readonly ILogger<LocalApiController> logger;

        public LocalApiController(IPoopingApiClient poopingApiClient, INotificationApiClient notificationApiClient, ILogger<LocalApiController> logger)
        {
            this.poopingApiClient = poopingApiClient;
            this.notificationApiClient = notificationApiClient;
            this.logger = logger;
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
            LogMethod(Request.Body);
            var addPoopingRequest = new AddPoopingRequest
            {
                AuthorName = request.AuthorName,
                WagePerHour = request.WagePerHour,
                Duration = TimeSpan.FromMilliseconds(request.DurationInMs)
            };
            await poopingApiClient.AddPooping(addPoopingRequest);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddSubscriber(AddSubscriberRequest request)
        {
            LogMethod(Request.Body);
            await notificationApiClient.AddSubscriber(request);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SendNotification(SendNotificationRequest request)
        {
            LogMethod(Request.Body);
            await notificationApiClient.SendNotification(request);
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
