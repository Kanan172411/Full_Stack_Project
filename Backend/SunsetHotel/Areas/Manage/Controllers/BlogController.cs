using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using SunsetHotel.Helpers;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Blogs.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<Blog> blogs = _context.Blogs.Include(x=>x.BlogCategory).Skip((page - 1) * 6).Take(6).ToList();
            return View(blogs);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!_context.BlogCategories.Any(x => x.Id == blog.BlogCategoryId))
            {
                ModelState.AddModelError("BlogCategoryId", "Cateqoriya mövcud deyil!");
                return View();
            }
            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View();
                }

                if (blog.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View();
                }

                blog.ImageName = FileManager.Save(_env.WebRootPath, "assets/img", blog.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image yuklemek mecburidir!");
                return View();
            }
            blog.BlogTags = new List<BlogTag>();
            if (blog.TagId != null)
            {
                foreach (var tagId in blog.TagId)
                {
                    BlogTag blogTag = new BlogTag
                    {
                        TagId = tagId
                    };
                    blog.BlogTags.Add(blogTag);
                }
            }

            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Blog blog = _context.Blogs.Include(x => x.BlogCategory).Include(x=>x.BlogTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id);

            if (blog == null) return RedirectToAction("error", "dashboard");
            blog.TagId = blog.BlogTags.Select(x => x.TagId).ToList();

            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Blog existBlog = _context.Blogs.Include(x=>x.BlogCategory).Include(x=>x.BlogTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == blog.Id);

            if (existBlog == null) return RedirectToAction("error", "dashboard");
            if (!_context.BlogCategories.Any(x => x.Id == blog.BlogCategoryId))
            {
                ModelState.AddModelError("BlogCAtegoryId", "Cateqoriya mövcud deyil!");
                return View();
            }

            existBlog.Name = blog.Name;
            existBlog.BlogPostTitle = blog.BlogPostTitle;
            existBlog.BlogCategoryId = blog.BlogCategoryId;
            existBlog.Desc1 = blog.Desc1;
            existBlog.DescHeader = blog.DescHeader;
            existBlog.Desc2 = blog.Desc2;
            existBlog.Createdat = blog.Createdat;

            existBlog.BlogTags.RemoveAll(x => !blog.TagId.Contains(x.BlogId));

            if (blog.TagId != null)
            {
                foreach (var tagId in blog.TagId)
                {
                    BlogTag blogTag = existBlog.BlogTags.FirstOrDefault(x => x.TagId == tagId);

                    if (blogTag == null)
                    {
                        blogTag = new BlogTag
                        {
                            BlogId = blog.Id,
                            TagId = tagId
                        };
                        existBlog.BlogTags.Add(blogTag);
                    }
                }
            }
            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View();
                }

                if (blog.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View();
                }


                string newFileName = FileManager.Save(_env.WebRootPath, "assets/img", blog.ImageFile);

                if (!string.IsNullOrWhiteSpace(existBlog.ImageName))
                {
                    string oldFilePath = Path.Combine(_env.WebRootPath, "assets/img", existBlog.ImageName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }


                existBlog.ImageName = newFileName;
            }
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Blog existBlog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (existBlog == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (!string.IsNullOrWhiteSpace(existBlog.ImageName))
            {
                FileManager.Delete(_env.WebRootPath, "assets/img", existBlog.ImageName);
            }
            _context.Blogs.Remove(existBlog);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
