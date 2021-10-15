using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            TempData["forSelect"] = 4;
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
