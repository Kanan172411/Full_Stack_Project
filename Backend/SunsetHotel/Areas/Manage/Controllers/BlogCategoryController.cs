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
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;
        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.BlogCategories.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<BlogCategory> blogCategories = _context.BlogCategories.Skip((page - 1) * 6).Take(6).ToList();
            return View(blogCategories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogCategory blogCategories)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.BlogCategories.Add(blogCategories);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            BlogCategory blogCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == id);

            if (blogCategory == null) return RedirectToAction("error", "dashboard");

            return View(blogCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogCategory blogCategory)
        {
            BlogCategory existBlogCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == blogCategory.Id);

            if (existBlogCategory == null) return RedirectToAction("error", "dashboard");

            existBlogCategory.Name = blogCategory.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            BlogCategory existBlogCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == id);
            if (existBlogCategory == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            _context.BlogCategories.Remove(existBlogCategory);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
