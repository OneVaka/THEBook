using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOOKcheck.Managers.Liber;
using BOOKcheck.Managers.User;
using BOOKcheck.Models;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Controllers
{
    public class UserPageController : Controller
    {
        private ILiberManager manager;
        private IPersonManager managerUser;

        public UserPageController(ILiberManager manager, IPersonManager managerUser)
        {
            this.manager = manager;
            this.managerUser = managerUser;
        }


        public async Task<IActionResult> Index()
        {
            string userCook = Request.Cookies["bookCookie"];
            string userLogin = Request.Cookies["Login"];

            if(userCook == "")
            {
                return RedirectToAction("Index", "Authorization");
            }
            else
            {
                if ( !(await managerUser.CheckCookie(userCook,userLogin)) )
                    return RedirectToAction("Index", "Authorization");
            }

            ICollection<UserLibModel> lib = new List<UserLibModel>();

            return View(lib);
        }




        [HttpPost]
        public async Task<IActionResult> getLib(int libOption)
        {
            var userLib = await manager.GetUserLib(libOption, Request.Cookies["Login"]);

            

            ICollection<UserLibModel> libModel = new List<UserLibModel>();

            UserLibModel temp = new UserLibModel();
            switch (libOption)
            {
                case 1:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.NowRead)
                        {
                            temp.Book = item_2.Book;
                            temp.Page = item_2.Page;
                            libModel.Add(temp);
                        }
                    break;
                case 2:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.FinishRead)
                        {
                            temp.Book = item_2.Book;
                            temp.Page = item_2.Page;
                            libModel.Add(temp);
                        }
                    break;
                case 3:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.WantRead)
                        {
                            temp.Book = item_2.Book;
                            temp.Page = item_2.Page;
                            libModel.Add(temp);
                        }
                    break;
                case 4:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.EndRead)
                        {
                            temp.Book = item_2.Book;
                            temp.Page = item_2.Page;
                            libModel.Add(temp);
                        }
                    break;
                default:
                    break;
            }
           
            return View("Index",libModel);
        }


        [HttpPost]
        public async Task<IActionResult> ChangePage(int newPage)
        {



            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("bookCookie");
            // manager.UserLogOut(ControllerContext);
            return RedirectToAction("Index", "Authorization");
        }


    }
}
