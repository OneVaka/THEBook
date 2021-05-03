using BOOKcheck.Managers.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKcheck.Controllers
{
    public class UserPageController : Controller
    {

        private IPersonManager manager;


        public UserPageController(IPersonManager manager)
        {

            this.manager = manager;

        }


        public IActionResult Registration()
        {

            
            string userCook = Request.Cookies["bookCookie"];
            if(userCook != "")
            {
                if (manager.CheckCookie(userCook))
                    return RedirectToAction("Bookstr");
            }

            return View();
        }

        public async Task<IActionResult> Bookstr()
        {
            string userCook = Request.Cookies["bookCookie"];
            if (userCook != "")
            {
                if (manager.CheckCookie(userCook))
                    return View();
            }
            return RedirectToAction("Registration");
        }


        [HttpPost]
        public async Task<IActionResult> Registration(string Mail, string Pass, string Login)
        {

           if( manager.AddUser(Mail, Pass, Login, ControllerContext))
           {
                manager.LogInUser(Login, Pass, ControllerContext);
                return RedirectToAction("Bookstr");
           }
           
            else
            {
                return RedirectToAction("Registration");
            }


        }


       [HttpPost]
       public async Task<IActionResult> Loggining(string Login, string Pass)
       {
            if (manager.LogInUser(Login, Pass,ControllerContext))
                return RedirectToAction("Bookstr");

            else
            {
                return RedirectToAction("Registration");
            }

        }

        [HttpPost]
        public IActionResult LogOut()
        {

            
            HttpContext.Response.Cookies.Delete("bookCookie");
           // manager.UserLogOut(ControllerContext);
            return RedirectToAction("Registration");
        }


    }
}
