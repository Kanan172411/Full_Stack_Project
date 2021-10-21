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
        public IActionResult Index(int? categoryId, int? Tagid, string search, int page=1)
        {
            TempData["forSelect"] = 4;

            var query = _context.Blogs.Include(x=>x.BlogCategory).Include(x=>x.BlogTags).ThenInclude(x=>x.Tag).AsQueryable();
            var queryBlogTag = _context.BlogTags.AsQueryable();
            if (categoryId != null)
            {
                query=query.Where(x => x.BlogCategoryId == categoryId);
                ViewBag.categoryId = categoryId;
            }
            if (Tagid != null)
            {
                var queryNew = queryBlogTag.Where(x => x.TagId == Tagid).ToList();
                List<Blog> blogs1 = new List<Blog>();
                foreach (var item in queryNew)
                {
                    blogs1.Add(_context.Blogs.Find(item.BlogId));
                }
                query = blogs1.AsQueryable();
                ViewBag.tagId = Tagid;
            }
            if (search != null)
            {
                ViewBag.search = search;
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }
            double pageCount = Math.Ceiling(query.Count() / 3d);
            if (page > pageCount)
            {
                return RedirectToAction("error", "home");
            }
            Setting setting = _context.Settings.FirstOrDefault();
            ViewBag.TotalPage = pageCount;
            ViewBag.SelectedPage = page;
            ViewBag.WelcomeContent = setting.BlogWelcomeContent;
            BlogViewModel blogVM = new BlogViewModel
            {
                blogs = query.Skip((page - 1) * 3).Take(3).ToList(),
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
