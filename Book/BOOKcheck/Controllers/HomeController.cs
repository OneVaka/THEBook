using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BOOKcheck.Models;
using BOOKcheck.Storage.Entity;

namespace BOOKcheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookManeger manager;
       

        public HomeController(ILogger<HomeController> logger , IBookManeger manager)
        {
            _logger = logger;
            this.manager = manager;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registr()
        {
            return View();
        }
        public IActionResult books()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
