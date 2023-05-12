using Microsoft.AspNetCore.Mvc;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public WeddingDBContext weddingDBContext;

        public RegisterController(WeddingDBContext _weddingDBContext)
        {
            weddingDBContext = _weddingDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
                using(var client = new HttpClient())
                {
                    using(var response = await client.PostAsJsonAsync<User>("https://localhost:7268/api/User/Add",user))
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
            return View(user);
        }
    }
}
