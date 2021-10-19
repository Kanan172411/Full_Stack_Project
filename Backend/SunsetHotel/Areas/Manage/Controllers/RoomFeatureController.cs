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
    public class RoomFeatureController : Controller
    {
        private readonly AppDbContext _context;
        public RoomFeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.RoomFeatures.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<RoomFeature> roomFeatures = _context.RoomFeatures.Skip((page - 1) * 6).Take(6).ToList();
            return View(roomFeatures);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomFeature roomFeature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.RoomFeatures.Add(roomFeature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            RoomFeature roomFeature = _context.RoomFeatures.FirstOrDefault(x => x.Id == id);

            if (roomFeature == null) return RedirectToAction("error", "dashboard");

            return View(roomFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomFeature roomFeature)
        {
            RoomFeature existRoomFeature = _context.RoomFeatures.FirstOrDefault(x => x.Id == roomFeature.Id);

            if (existRoomFeature == null) return RedirectToAction("error", "dashboard");

            existRoomFeature.Name = roomFeature.Name;
            existRoomFeature.Icon = roomFeature.Icon;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            RoomFeature existRoomFeature = _context.RoomFeatures.FirstOrDefault(x => x.Id == id);
            if (existRoomFeature == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.RoomFeatures.Remove(existRoomFeature);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
