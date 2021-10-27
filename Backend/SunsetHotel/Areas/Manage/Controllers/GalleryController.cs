using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SunsetHotel.DAL;
using SunsetHotel.Helpers;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GalleryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Galleries.Count() / 8d);
            List<Gallery> galleries = _context.Galleries.Skip((page - 1) * 8).Take(8).ToList();
            return View(galleries);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gallery gallery)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (gallery.ImageFile != null)
            {
                if (gallery.ImageFile.ContentType != "image/jpeg" && gallery.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View();
                }

                if (gallery.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View();
                }

                gallery.ImageName = FileManager.Save(_env.WebRootPath, "assets/img", gallery.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image yuklemek mecburidir!");
                return View();
            }

            _context.Galleries.Add(gallery);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Gallery existGallery = _context.Galleries.FirstOrDefault(x => x.Id == id);
            if (existGallery == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (!string.IsNullOrWhiteSpace(existGallery.ImageName))
            {
                FileManager.Delete(_env.WebRootPath, "assets/img", existGallery.ImageName);
            }
            _context.Galleries.Remove(existGallery);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
