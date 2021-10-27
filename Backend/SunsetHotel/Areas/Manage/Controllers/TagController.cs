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
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Tags.Count() / 6d);

            List<Tag> tags = _context.Tags.Skip((page - 1) * 6).Take(6).ToList();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (tag == null) return RedirectToAction("error", "dashboard");

            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tag tag)
        {
            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);

            if (existTag == null) return RedirectToAction("error", "dashboard");

            existTag.Name = tag.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (existTag == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.Tags.Remove(existTag);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
