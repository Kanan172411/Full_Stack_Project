using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _context;
        public SubscriberController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Tags.Count() / 10d);

            List<Subscriber> subscribers = _context.Subscribers.Skip((page - 1) * 10).Take(10).ToList();
            return View(subscribers);
        }
    }
}
