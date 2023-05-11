using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class ServiceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var services = new List<Service>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7268/api/Service/Getall"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    services = JsonConvert.DeserializeObject<List<Service>>(apiResponse);
                }
            }
            return View(services);
        }
    }
}
