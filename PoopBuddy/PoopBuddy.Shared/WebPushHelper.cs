using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using WebPush;

namespace PoopBuddy.Shared
{
    public static class WebPushHelper
    {
        public static void SendNotification(string message, string pushEndpoint, string p256dh, string auth)
        {
            var webPushClient = new WebPushClient();
            var pushSubscription = new PushSubscription(pushEndpoint,p256dh,auth);
            try
            {
                //var notification = new WebPushNotification
                //{
                //    title = "New notification",
                //    body = message,
                //    vibrate = new[] {100, 50, 100},
                //    data = new Data
                //    {
                //        dateOfArrival = DateTime.Now.ToShortTimeString(),
                //        primaryKey = 1
                //    },
                //    actions = new[]
                //    {
                //        new Action
                //        {
                //            action = "explore",
                //            title = "go to to"
                //        },
                //    }
                //};

                var notification = "{\"notification\":{\"title\":\"Ktoś zaczął srać\",\"body\":\"{MESSAGE}\",\"icon\":\"https://cdn3.iconfinder.com/data/icons/object-emoji/50/Poop-512.png\",\"vibrate\":[100,50,100],\"data\":{\"url\":\"https://medium.com/@arjenbrandenburgh/angulars-pwa-swpush-and-swupdate-15a7e5c154ac\"}}}";
                notification = notification.Replace("{MESSAGE}", message);
                webPushClient.SendNotification(pushSubscription, notification, new VapidDetails
                {
                    Subject = "mailto:kuker16@gmail.com",
                    PublicKey = "BPJC0G2ZjJvF-eEdN5qiUVTTz4zBX3kC2k5KzyziRl2mKt9Tj5yulvAwNXfgr1B2CpNyX5p_M4UfS4bqxDiSMDE",
                    PrivateKey = "iZoBvDdIsFiAfabJGCIqmtjaAH7N4Nwp-mNwobNlkPY"
                });
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.ToString());
            }
        }
    }

    class WebPushNotification
    {
        public string title { get; set; }
        public string body { get; set; }
        public int[] vibrate { get; set; }
        public Data data { get; set; }
        public Action[] actions { get; set; }
    }

    class Data
    {
        public string dateOfArrival { get; set; }
        public int primaryKey { get; set; }
    }

    class Action
    {
        public string action { get; set; }
        public string title { get; set; }
    }
}
