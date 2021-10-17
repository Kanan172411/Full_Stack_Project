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
    public class RoomCategoryController : Controller
    {
        private readonly AppDbContext _context;
        public RoomCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.RoomCategories.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<RoomCategory> roomCategories = _context.RoomCategories.Skip((page - 1) * 6).Take(6).ToList();
            return View(roomCategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomCategory roomCategories)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.RoomCategories.Add(roomCategories);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            RoomCategory roomCategory = _context.RoomCategories.FirstOrDefault(x => x.Id == id);

            if (roomCategory == null) return RedirectToAction("error", "dashboard");

            return View(roomCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomCategory roomCategory)
        {
            RoomCategory existRoomCategory = _context.RoomCategories.FirstOrDefault(x => x.Id == roomCategory.Id);

            if (existRoomCategory == null) return RedirectToAction("error", "dashboard");

            existRoomCategory.Name = roomCategory.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            RoomCategory existRoomCategory = _context.RoomCategories.FirstOrDefault(x => x.Id == id);
            if (existRoomCategory == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.RoomCategories.Remove(existRoomCategory);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
