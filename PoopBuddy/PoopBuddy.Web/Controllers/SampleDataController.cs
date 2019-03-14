using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PoopBuddy.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<Pooping> Poopings()
        {
            var httpClient = new HttpClient();
            var poopings = httpClient.GetAsync("https://localhost:44329/api/poopings/GetAll");
            var result = poopings.Result;
            var content = result.Content;
            var stringContent = content.ReadAsStringAsync().Result;

            GetAllPoopingsResponse response = JsonConvert.DeserializeObject<GetAllPoopingsResponse>(stringContent);
            var testobj = JsonConvert.DeserializeObject(stringContent);

            return response.Poopings;
        }


        public class GetAllPoopingsResponse
        {
            [JsonProperty(PropertyName = "poopings")]
            public List<Pooping> Poopings { get; set; }
        }

        public class Pooping
        {
            [JsonProperty(PropertyName = "poopingTitle")]
            public string PoopingTitle { get; set; }
            [JsonProperty(PropertyName = "duration")]
            public TimeSpan Duration { get; set; }
            [JsonProperty(PropertyName = "earning")]
            public decimal Earning { get; set; }
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
