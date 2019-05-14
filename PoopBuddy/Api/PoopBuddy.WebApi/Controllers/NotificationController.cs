using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoopBuddy.Data.Logic;
using PoopBuddy.Shared.DTO.Notification;

namespace PoopBuddy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly INotificationLogic notificationLogic;
        private readonly ILogger<NotificationController> logger;

        public NotificationController(INotificationLogic notificationLogic, ILogger<NotificationController> logger)
        {
            this.notificationLogic = notificationLogic;
            this.logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddSubscriber(AddSubscriberRequest request)
        {
            LogMethod();
            notificationLogic.AddSubscriber(request);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult SendNotification(SendNotificationRequest request)
        {
            LogMethod();
            notificationLogic.SendNotification(request);
            return Ok();
        }

        private void LogMethod([CallerMemberName] string action = "")
        {
            logger.LogDebug(action);
        }
    }
}
