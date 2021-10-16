using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using SunsetHotel.ViewModels;
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
            HomeViewModel homeVM = new HomeViewModel
            {
                setting = _context.Settings.FirstOrDefault(),
                rooms1 = _context.Rooms.Include(x => x.RoomImages).Take(2).ToList(),
                rooms2 = _context.Rooms.Include(x => x.RoomImages).Skip(2).Take(2).ToList(),
                features = _context.Features.ToList(),
                galleries = _context.Galleries.ToList(),
                testimonials = _context.Testimonials.ToList(),
                blogs1 = _context.Blogs.Take(3).ToList(),
                blogs2 = _context.Blogs.Skip(3).Take(3).ToList(),
            };

            return View(homeVM);
        }

        public IActionResult Contact()
        {
            TempData["forSelect"] = 5;

            Setting setting = _context.Settings.FirstOrDefault();

            return View(setting);
        }
        
        public IActionResult About()
        {
            TempData["forSelect"] = 2;

            AboutViewModel aboutVM = new AboutViewModel
            {
                setting = _context.Settings.FirstOrDefault(),
                ourServices1 = _context.OurServices.Take(2).ToList(),
                ourServices2 = _context.OurServices.Skip(2).Take(2).ToList(),
                testimonials = _context.Testimonials.ToList()
            };

            return View(aboutVM);
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
