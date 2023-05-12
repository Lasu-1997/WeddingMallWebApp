using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = new List<Category>();

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7268/api/Category/Getall"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(categories);
        }
    }
}
