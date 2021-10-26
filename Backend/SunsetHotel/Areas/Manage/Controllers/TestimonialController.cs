using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Testimonials.Count() / 6d);
            if (page> ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<Testimonial> testimonials = _context.Testimonials.Skip((page - 1) * 6).Take(6).ToList();
            return View(testimonials);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (testimonial.ImageFile != null)
            {
                if (testimonial.ImageFile.ContentType != "image/jpeg" && testimonial.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View();
                }

                if (testimonial.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View();
                }

                testimonial.ImageName = FileManager.Save(_env.WebRootPath, "assets/img", testimonial.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image yuklemek mecburidir!");
                return View();
            }

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);

            if (testimonial == null) return RedirectToAction("error", "dashboard");

            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Testimonial existTestimonial = _context.Testimonials.FirstOrDefault(x => x.Id == testimonial.Id);

            if (existTestimonial == null) return RedirectToAction("error", "dashboard");

            existTestimonial.FullName = testimonial.FullName;
            existTestimonial.Profession = testimonial.Profession;
            existTestimonial.Desc = testimonial.Desc;
            if (testimonial.ImageFile != null)
            {
                if (testimonial.ImageFile.ContentType != "image/jpeg" && testimonial.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View(existTestimonial);
                }

                if (testimonial.ImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View(existTestimonial);
                }


                string newFileName = FileManager.Save(_env.WebRootPath, "assets/img", testimonial.ImageFile);

                if (!string.IsNullOrWhiteSpace(existTestimonial.ImageName))
                {
                    string oldFilePath = Path.Combine(_env.WebRootPath, "assets/img", existTestimonial.ImageName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }


                existTestimonial.ImageName = newFileName;
            }
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Testimonial existTestimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (existTestimonial == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            if (!string.IsNullOrWhiteSpace(existTestimonial.ImageName))
            {
                FileManager.Delete(_env.WebRootPath, "assets/img", existTestimonial.ImageName);
            }
            _context.Testimonials.Remove(existTestimonial);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
