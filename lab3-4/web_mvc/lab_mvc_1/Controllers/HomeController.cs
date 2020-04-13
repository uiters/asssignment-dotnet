using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lab_mvc_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab_mvc_1.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController (ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index () {
            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool CheckAccount (string username, string password) {
            Account acc = AccountData.AccountList.FirstOrDefault (c => c.UserName.Equals (username) &&
                c.Password.Equals (password));

            if (acc == null) {
                return false;
            }
            return true;
        }

        [HttpPost]
        public ActionResult CheckLogin (string username, string password) {
            ViewBag.Title = "Login to website";

            if (CheckAccount (username, password)) {
                ViewBag.Message = "User " + username + " logged in successful.";
            } else {
                ViewBag.Message = "User " + username + " logged in fail";

            }
            return View ("LoginResult");
        }
    }
}