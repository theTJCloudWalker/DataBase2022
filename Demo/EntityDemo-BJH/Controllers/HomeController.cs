using EntityDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntityDemo.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        private static int userNum = 0;

        // 显示用户
        public IActionResult Index() {
            MyContext db  = new MyContext();
            var list = db.Db11.Queryable<User>().ToList();
            return View(list);
        }

        // 增加测试用户
        public IActionResult AddUser() {
            MyContext context = new MyContext();
            var newUser = new User {
                Phone_Number = "17830827328",
                Name = "guest"+(++userNum).ToString(),
                Passenger_ID = "500103xxxxxxxxxxxx",
                Id = userNum.ToString(),
                Password = "DefaultPassword"
            };
            Console.WriteLine(newUser.ToString());
            context.Db11.Insertable(newUser).ExecuteCommand();
            return RedirectToAction("Index");
        }

        // 删除用户
        public IActionResult DeleteUser(int? Id) {
            MyContext db = new MyContext();
            db.Db11.Deleteable<User>(Id).ExecuteCommand();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}