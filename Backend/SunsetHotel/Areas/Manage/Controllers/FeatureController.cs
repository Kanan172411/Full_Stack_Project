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
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Features.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<Feature> features = _context.Features.Skip((page - 1) * 6).Take(6).ToList();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Features.Add(feature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);

            if (feature == null) return RedirectToAction("error", "dashboard");

            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Feature feature)
        {
            Feature existFeature = _context.Features.FirstOrDefault(x => x.Id == feature.Id);

            if (existFeature == null) return RedirectToAction("error", "dashboard");

            existFeature.Name = feature.Name;
            existFeature.Desc = feature.Desc;
            existFeature.StarCount = feature.StarCount;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Feature existFeature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (existFeature == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.Features.Remove(existFeature);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
