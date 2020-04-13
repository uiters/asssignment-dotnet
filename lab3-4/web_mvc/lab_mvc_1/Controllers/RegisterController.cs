using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab_mvc_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_mvc_1.Controllers {
        public class RegisterController : Controller {

            public ActionResult Index () {
                return View ();
            }

            [HttpPost]
            public ViewResult AddNewAccount (string username, string password) {
                AccountData.AccountList.Add (new Account { UserName = username, Password = password });
                ViewBag.Message = "Account added successful";
                    return View ("Index");
                }
            }
        }