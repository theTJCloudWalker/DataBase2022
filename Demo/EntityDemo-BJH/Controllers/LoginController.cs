using Microsoft.AspNetCore.Mvc;

namespace EntityDemo.Controllers {
    public class LoginController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
