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
    public class OurServiceController : Controller
    {
        private readonly AppDbContext _context;
        public OurServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.OurServices.Count() / 6d);

            List<OurService> ourServices = _context.OurServices.Skip((page - 1) * 6).Take(6).ToList();
            return View(ourServices);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OurService ourService)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.OurServices.Add(ourService);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            OurService ourService = _context.OurServices.FirstOrDefault(x => x.Id == id);

            if (ourService == null) return RedirectToAction("error", "dashboard");

            return View(ourService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OurService ourService)
        {
            OurService existOurService = _context.OurServices.FirstOrDefault(x => x.Id == ourService.Id);

            if (existOurService == null) return RedirectToAction("error", "dashboard");

            existOurService.Name = ourService.Name;
            existOurService.Desc = ourService.Desc;
            existOurService.Icon = ourService.Icon;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            OurService existOurService = _context.OurServices.FirstOrDefault(x => x.Id == id);
            if (existOurService == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.OurServices.Remove(existOurService);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
