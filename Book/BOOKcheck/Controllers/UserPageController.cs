using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOOKcheck.Managers.Liber;
using BOOKcheck.Managers.User;
using BOOKcheck.Managers.Book;
using BOOKcheck.Models;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Controllers
{
    public class UserPageController : Controller
    {
        private ILiberManager manager;
        private IPersonManager managerUser;
        private IBookManeger managerBook;

        public UserPageController(ILiberManager manager, IPersonManager managerUser, IBookManeger bookManeger)
        {
            this.manager = manager;
            this.managerUser = managerUser;
            this.managerBook = bookManeger;
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

            //ICollection<UserLibModel> lib = new List<UserLibModel>();
            
            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> getRandom()
        {
            var ranBook = await managerBook.GetRandomBook();
            UserLibModel temp = new UserLibModel();
            temp.Book = ranBook;
            temp.Page = null;
            List<UserLibModel> libModel = new List<UserLibModel>();
            libModel.Add(temp);

            return View("Index", libModel);
        }


        [HttpPost]
        public async Task<IActionResult> getLib(int libOption)
        {
            var userLib = await manager.GetUserLib(libOption, Request.Cookies["Login"]);

            

            List<UserLibModel> libModel = new List<UserLibModel>();
            UserLibModel temp = null;


            switch (libOption)
            {
                case 1:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.NowRead)
                        {
                            temp = new UserLibModel();
                            temp.Book = item_2.Book;
                            temp.Page = item_2.Page;

                            libModel.Add(temp);
                        }
                    break;
                case 2:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.FinishRead)
                        {
                            temp = new UserLibModel();
                            temp.Book = item_2.Book;
                            temp.Page = null;

                            libModel.Add(temp);
                        }
                    break;
                case 3:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.WantRead)
                        {
                            temp = new UserLibModel();
                            temp.Book = item_2.Book;
                            temp.Page = null;

                            libModel.Add(temp);
                        }
                    break;
                case 4:
                    foreach (var item in userLib)
                        foreach (var item_2 in item.EndRead)
                        {
                            temp = new UserLibModel();
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
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("bookCookie");
            // manager.UserLogOut(ControllerContext);
            return RedirectToAction("Index", "Authorization");
        }


    }
}
