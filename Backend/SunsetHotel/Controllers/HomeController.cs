using Microsoft.AspNetCore.Mvc;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TempData["forSelect"] = 1;
            return View();
        }

        public IActionResult Contact()
        {
            TempData["forSelect"] = 5;
            return View();
        }
        
        public IActionResult About()
        {
            TempData["forSelect"] = 2;
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
