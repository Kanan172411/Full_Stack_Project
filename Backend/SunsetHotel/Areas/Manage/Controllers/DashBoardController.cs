using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int monthly = 0;
            foreach (var item in _context.Reservations.Include(x => x.room).Where(x => x.Status == true && x.CheckIn >= DateTime.Now.AddMonths(-1) && x.CheckOut <= DateTime.Now))
            {
                monthly += item.NightCount * item.room.Price;
            }
            ViewBag.monthly = monthly;
            int annual = 0;
            foreach (var item in _context.Reservations.Include(x => x.room).Where(x => x.Status == true && x.CheckIn >= DateTime.Now.AddYears(-1) && x.CheckOut <= DateTime.Now))
            {
                annual += item.NightCount * item.room.Price;
            }
            ViewBag.Annual = annual;
            double allBooking = _context.Reservations.Count();
            double acceptedBooking = _context.Reservations.Where(x => x.Status == true).Count();
            ViewBag.AcceptedPercent = (int)acceptedBooking * 100 / (int)allBooking;
            ViewBag.Pending = _context.Reservations.Where(x => x.Status == null).Count();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
