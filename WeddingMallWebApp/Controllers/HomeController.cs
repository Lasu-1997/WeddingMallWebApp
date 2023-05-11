using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var services = new List<Service>();
            using(var client = new HttpClient())
            {
                using(var response = await client.GetAsync("https://localhost:7268/api/Service/Getall"))
                {
                    var apiResponse =  await response.Content.ReadAsStringAsync();
                    services = JsonConvert.DeserializeObject<List<Service>>(apiResponse);
                }
            }
            return View(services);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}