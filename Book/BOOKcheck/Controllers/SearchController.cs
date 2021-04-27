using BOOKcheck.Managers.Book;
using BOOKcheck.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKcheck.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private IBookManeger manager;

        public SearchController(ILogger<SearchController> logger, IBookManeger manager)
        {
            _logger = logger;
            this.manager = manager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search()
        {
            
            var bookTable = await manager.GetAll();
            return View(bookTable);
        }

        [HttpPost]
        public async Task<IActionResult> FindAutor(string name)
        {
           var bookTable = await manager.GetAutor(name);
            return View("Search", bookTable);
        }

        [HttpPost]
        public async Task<IActionResult> FindBook(string name)
        {
            var bookTable = await manager.GetBook(name);
            return View("Search", bookTable);
           
        }

        [HttpPost]
        public async Task<IActionResult> FindGenre(int genreID)
        {
            var bookTable = await manager.GetGenre(genreID);
            return View("Search", bookTable);
        }

        [HttpPost]
        public async Task<IActionResult> FindRating(double rateDown,double rateUpper)
        {
            var bookTable = await manager.PridelRating( rateDown,  rateUpper);
            return View("Search", bookTable);
        }

    }
}
