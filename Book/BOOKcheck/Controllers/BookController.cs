using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Managers.Book;
using BOOKcheck.Managers.Liber;
using BOOKcheck.Managers.User;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Controllers
{
    public class BookController : Controller
    {
        private ILiberManager manager;
        private IPersonManager personManager;
        private IBookManeger bookManager;

        public BookController(ILiberManager maneger, IPersonManager personManager, IBookManeger bookManager)
        {
            this.personManager = personManager;
            this.manager = maneger;
            this.bookManager = bookManager;
            
        }

        public async Task<IActionResult> Index()
        {
            
            var book = await manager.GetAllEnd(1);
            return  View(book);
        }

        [HttpGet("Book/{bookId}")]
        public IActionResult Bookstr(int bookId)
        {
            var model = bookManager.GetBookById(bookId).Result;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetUserLibBook(int bookId,int libOption,int page = 0)
        {
            string userLogin = HttpContext.Request.Cookies["Login"];

               int idLiberUser = personManager.GetIdLiber(userLogin);

               manager.RemoveBook(idLiberUser, bookId);

               switch (libOption)
               {
                   case 1:
                       manager.AddBookNow(idLiberUser,bookId,page);
                       break;
                   case 2:
                       manager.AddBookFinish(idLiberUser, bookId, page);
                       break;
                   case 3:
                       manager.AddBookWant(idLiberUser, bookId, page);
                       break;
                   case 4:
                       manager.AddBookEnd(idLiberUser, bookId, page);
                       break;
                   default:
                       break;
               }

               return LocalRedirect($"~/Book/{bookId}");
        }
    }
}