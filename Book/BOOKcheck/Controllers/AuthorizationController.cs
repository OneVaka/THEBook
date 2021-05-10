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

            
            string userCook = Request.Cookies["bookCookie"];
            if(userCook != "")
            {
                if (manager.CheckCookie(userCook))
                    return RedirectToAction("Index","UserPage");
            }

            return View();
        }    

        [HttpPost]
        public async Task<IActionResult> Registration(string Mail, string Pass, string Login)
        {
            
            if (manager.AddUser(Mail, Pass, Login, ControllerContext))
                return RedirectToAction("Index", "UserPage");

            else
                return RedirectToAction("Index");
        }


       [HttpPost]
       public async Task<IActionResult> Loggining(string Login, string Pass)
       {
            string x = Request.Form.FirstOrDefault(k => k.Key == "Login").Value;        

            if (manager.LogInUser(Login, Pass,ControllerContext))
                return RedirectToAction("Index", "UserPage");

            else
                return RedirectToAction("Index");
       }


    }
}
