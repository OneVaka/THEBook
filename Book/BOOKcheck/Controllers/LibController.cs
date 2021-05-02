using System;
using System.Threading.Tasks;
using BOOKcheck.Managers.Liber;
using Microsoft.AspNetCore.Mvc;

namespace BOOKcheck.Controllers
{
    public class LibController : Controller
    {
        private ILiberManager manager;

        public LibController(ILiberManager manager)
        {
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var lib = manager.GetAllEnd(1);

            manager.RemoveBook(1,5);

            return View(lib);
        }

        
    }
}
