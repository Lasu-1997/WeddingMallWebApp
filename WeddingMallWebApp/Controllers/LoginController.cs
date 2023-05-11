using Microsoft.AspNetCore.Mvc;
using WeddingMallWebApp.Models;

namespace WeddingMallWebApp.Controllers
{
    public class LoginController : Controller
    {
        public WeddingDBContext weddingDBContext;

        public LoginController(WeddingDBContext _weddingDBContext)
        {
            weddingDBContext = _weddingDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = weddingDBContext.User.FirstOrDefault(q=>q.UserName == username && q.Password == password);

            if(user != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
