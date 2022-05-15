using BOOKcheck.Managers.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKcheck.Controllers
{
    public class AuthorizationController : Controller
    {

        private IPersonManager manager;


        public AuthorizationController(IPersonManager manager)
        {

            this.manager = manager;

        }


        public async Task<IActionResult> Index()
        {

            string userLogin = Request.Cookies["Login"];
            string userCook = Request.Cookies["bookCookie"];

            if(userCook != "")
            {
                if (await manager.CheckCookie(userCook,userLogin))
                    return RedirectToAction("Index","UserPage");
            }

            return View();
        }    

        [HttpPost]
        public async Task<IActionResult> Registration(string Mail, string Pass, string Login)
        {

            if (await manager.AddUser(Mail, Pass, Login, ControllerContext))
                return RedirectToAction("Index", "UserPage");

            else
            {
                //НУЖНА МОДЕЛЬ ДЛЯ HTML
               // ModelState.AddModelError("Mail", "Данная почта уже используется");

                return RedirectToAction("Index");
            }
        }


       [HttpPost]
       public async Task<IActionResult> Loggining(string Login, string Pass)
       {
            string x = Request.Form.FirstOrDefault(k => k.Key == "Login").Value;        

            if (await manager.LogInUser(Login, Pass,ControllerContext))
                return RedirectToAction("Index", "UserPage");

            else
                return RedirectToAction("Index");
       }


    }
}
