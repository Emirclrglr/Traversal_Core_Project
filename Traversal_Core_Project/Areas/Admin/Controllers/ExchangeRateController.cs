using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Core_Project.Areas.Admin.Models;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ExchangeRateController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ExchangeRates_VM2> exchangeRates = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "c18ad4d8admsha7a40cbcaf75333p13586ajsn799e01380ceb" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                }
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ExchangeRates_VM2>(body);
            return View(values.exchange_rates);
        }
    }
}
