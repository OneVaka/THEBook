using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Managers.Book;
using BOOKcheck.Managers.Liber;
using BOOKcheck.Managers.User;
using Microsoft.AspNetCore.Mvc;
using BOOKcheck.Models;

namespace BOOKcheck.Controllers
{
    public class BookController : Controller
    {
        private ILiberManager manager;
        private IPersonManager personManager;
        private IBookManeger bookManager;

        public BookController(ILiberManager manager, IPersonManager personManager, IBookManeger bookManager)
        {
            this.personManager = personManager;
            this.manager = manager;
            this.bookManager = bookManager;
            
        }

        public async Task<IActionResult> Index()
        {
            
            var book = await manager.GetAllEnd(1);
            return  View(book);
        }

        [HttpGet("Book/{bookId}")]
        public async Task<IActionResult> Bookstr(int bookId)
        {
            BookModel model = new BookModel();

            var book = await bookManager.GetBookById(bookId);

            //если нет книги с заданным АйДи
            if(book == null)
            {
                return NotFound();             //("Похоже данной книги нет в нашей библиотеке :c");
            }
            model.Book = book;
            model.LibOption = await manager.BookCategory(await personManager.GetIdLiber(Request.Cookies["Login"]), bookId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetUserLibBook(int bookId,int libOption,int page = 0,int rate = 0)
        {
            string userLogin = HttpContext.Request.Cookies["Login"];

               int idLiberUser = await personManager.GetIdLiber(userLogin); 

               await manager.RemoveBook(idLiberUser, bookId);

               switch (libOption)
               {
                   case 1:
                     await  manager.AddBookNow(idLiberUser,bookId, page);
                       break;
                   case 2:
                     await  manager.AddBookFinish(idLiberUser, bookId, 0,rate);
                       break;
                   case 3:
                      await manager.AddBookWant(idLiberUser, bookId, 0);
                       break;
                   case 4:
                      await manager.AddBookEnd(idLiberUser, bookId, page,rate);
                       break;
                   default:
                       break;
               }

               return LocalRedirect($"~/Book/{bookId}");
        }




        [HttpPost]
        public async Task<IActionResult> newPage(int newPage,int bookID2)
        {
            string userLogin = HttpContext.Request.Cookies["Login"];
            int idLiberUser = await personManager.GetIdLiber(userLogin);

            await manager.ChangePageNumber(bookID2, idLiberUser, newPage);

            return LocalRedirect($"~/Book/{bookID2}");
        }



    }
}