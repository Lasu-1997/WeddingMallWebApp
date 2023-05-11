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
        public IActionResult Index(User user)
        {
            if(ModelState.IsValid)
            {
                weddingDBContext.User.Add(user);
                weddingDBContext.SaveChanges();
            }
            return View(user);
        }
    }
}
