using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using SunsetHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            TempData["forSelect"] = 4;
            double pageCount = Math.Ceiling(_context.Blogs.Count() / 3d);
            if (page>pageCount)
            {
                return RedirectToAction("error", "home");
            }
            ViewBag.TotalPage = pageCount;
            ViewBag.SelectedPage = page;
            Setting setting = _context.Settings.FirstOrDefault();
            ViewBag.WelcomeContent = setting.BlogWelcomeContent;
            BlogViewModel blogVM = new BlogViewModel
            {
                blogs = _context.Blogs.Include(x => x.BlogCategory).Include(x => x.BlogTags).Skip((page - 1) * 3).Take(3).ToList(),
                tags = _context.Tags.ToList(),
                categories = _context.BlogCategories.ToList(),
                recentPost = _context.Blogs.OrderByDescending(x=>x.Createdat).Take(4).ToList()
            };
            return View(blogVM);
        }

        public IActionResult Details(int? id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (blog==null)
            {
                return RedirectToAction("error", "home");
            }
            BlogDetailViewModel blogVM = new BlogDetailViewModel
            {
                tags = _context.Tags.ToList(),
                blogCategories = _context.BlogCategories.ToList(),
                recentPost = _context.Blogs.OrderByDescending(x => x.Createdat).Take(4).ToList(),
                blog = _context.Blogs.Where(x => x.Id == id).Include(x => x.BlogCategory).Include(x => x.BlogTags).ThenInclude(x => x.Tag).FirstOrDefault()
            };
            return View(blogVM);
        }
    }
}
