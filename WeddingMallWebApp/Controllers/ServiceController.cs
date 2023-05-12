using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class ServiceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var tupleModel =  new Tuple<List<Category>,List<Service>>(await GetCategories(), await GetServices());

            return View(tupleModel);
        } 
        private async Task<List<Category>> GetCategories()
        {
            var categories = new List<Category>();
            using(var client = new HttpClient())
            {
                using(var response = await client.GetAsync("https://localhost:7268/api/Category/Getall"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return categories;
        }
        private async Task<List<Service>> GetServices()
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

            return services;
        }
        
        
    }
}
