using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoopBuddy.Data.Logic;
using PoopBuddy.Shared.DTO.Notification;

namespace PoopBuddy.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly INotificationLogic notificationLogic;

        public NotificationController(INotificationLogic notificationLogic)
        {
            this.notificationLogic = notificationLogic;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddSubscriber(AddSubscriberRequest request)
        {
            notificationLogic.AddSubscriber(request);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult SendNotification(SendNotificationRequest request)
        {
            notificationLogic.SendNotification(request);
            return Ok();
        }
    }
}
