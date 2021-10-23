using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(int? categoryId, int? Tagid, string search, int page=1)
        {
            TempData["forSelect"] = 4;

            var query = _context.Blogs.Include(x=>x.Comments).Include(x=>x.BlogCategory).Include(x=>x.BlogTags).ThenInclude(x=>x.Tag).AsQueryable();
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
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.BlogPostTitle.ToLower().Contains(search.ToLower()));
                ViewBag.search = search;
            }
            double pageCount = Math.Ceiling(query.Count() / 3d);

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
                blog = _context.Blogs.Where(x => x.Id == id).Include(x => x.BlogCategory).Include(x=>x.Comments).Include(x => x.BlogTags).ThenInclude(x => x.Tag).FirstOrDefault()
            };
            return View(blogVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(BlogComment comment)
        {
            Blog blog = _context.Blogs.Where(x => x.Id == comment.BlogId).FirstOrDefault();
            if (blog==null)
            {
                return RedirectToAction("error", "home");
            }
            BlogComment blogComment = new BlogComment();
            if (User.IsInRole("Member"))
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                blogComment.Name = appUser.FullName;
                blogComment.Email = appUser.Email;
            }
            else
            {
                if (comment.Name.Length < 7 || comment.Email.Length < 6 || comment.Name.Length > 50 || comment.Email.Length > 60)
                {
                    TempData["Alert"] = "Commenti düzgün formatda daxil edin";
                    TempData["Type"] = "danger";
                    return RedirectToAction("details", "blog", new { id = comment.BlogId });
                }
                blogComment.Name = comment.Name;
                blogComment.Email = comment.Email;
            }
            if (comment.Text.Length < 10 || comment.Text.Length > 300)
            {
                TempData["Alert"] = "Commenti düzgün formatda daxil edin";
                TempData["Type"] = "danger";
                return RedirectToAction("details", "blog", new { id = comment.BlogId });
            }
            blogComment.BlogId = comment.BlogId;
            blogComment.Text = comment.Text;
            blogComment.CreatedAt = DateTime.Now;
            _context.BlogComments.Add(blogComment);
            _context.SaveChanges();
            TempData["Alert"] = "Comment əlavə edildi";
            TempData["Type"] = "success";
            return RedirectToAction("details", "blog", new { id = comment.BlogId });
        }
    }
}
