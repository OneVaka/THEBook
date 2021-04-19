using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKcheck.Managers.Book;
using BOOKcheck.Storage;
using BOOKcheck.Storage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Controllers
{
    public class BookController : Controller
    {
        private IBookManeger maneger;

        public BookController(IBookManeger maneger)
        {
            this.maneger = maneger;
        }

        public IActionResult Index()
        {
            var book = maneger.GetAll();
            return View(book);
        }
    }
}