using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Automation demo site";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Magenic";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
