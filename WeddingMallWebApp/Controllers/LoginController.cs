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
        public IActionResult Index(User user)
        {
            var userdb = weddingDBContext.User.FirstOrDefault(q=>q.UserName == user.UserName && q.Password == user.Password);

            if(user != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
