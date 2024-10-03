using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Traversal_Core_Project.Areas.Admin.Models;


namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class MovieAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<MovieAPI_VM> apiMovies = new();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "x-rapidapi-key", "c18ad4d8admsha7a40cbcaf75333p13586ajsn799e01380ceb" },
                    { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<MovieAPI_VM>>(body);
                return View(apiMovies);
            }
        }
    }
}
