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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            return View(setting);
        }
        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);

            if (setting == null) return RedirectToAction("error", "dashboard");

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Setting setting)
        {
            Setting existData = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);

            if (existData == null) return RedirectToAction("error", "dashboard");
            existData.LogoPart1 = setting.LogoPart1;
            existData.LogoPart2 = setting.LogoPart2;
            existData.WelcomeContent = setting.WelcomeContent;
            existData.AboutTitle = setting.AboutTitle;
            existData.AboutDesc1 = setting.AboutDesc1;
            existData.AboutDesc2 = setting.AboutDesc2;
            existData.OurbestRoomsTitle = setting.OurbestRoomsTitle;
            existData.OurGalleryTitle = setting.OurGalleryTitle;
            existData.TestimonialsTitle = setting.TestimonialsTitle;
            existData.Address = setting.Address;
            existData.PhoneNumber1 = setting.PhoneNumber1;
            existData.PhoneNumber2 = setting.PhoneNumber2;
            existData.Email = setting.Email;
            existData.AboutWelcomeContent = setting.AboutWelcomeContent;
            existData.GuestsStay = setting.GuestsStay;
            existData.RoomsCount = setting.RoomsCount;
            existData.Awards = setting.Awards;
            existData.MealServed = setting.MealServed;
            existData.OurServicesTitle = setting.OurServicesTitle;
            existData.AboutEndBannerText = setting.AboutEndBannerText;
            existData.ByWho = setting.ByWho;
            existData.RoomWelcomeContent = setting.RoomWelcomeContent;
            existData.BlogWelcomeContent = setting.BlogWelcomeContent;
            existData.ContactUsWelcomeContent = setting.ContactUsWelcomeContent;
            existData.ReservationWelcomeContent = setting.ReservationWelcomeContent;
            existData.ReservationTitle = setting.ReservationTitle;
            existData.InfoTitle = setting.InfoTitle;
            if (setting.AboutBannerImageFile != null)
            {
                if (setting.AboutBannerImageFile.ContentType != "image/jpeg" && setting.AboutBannerImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl   .jpg ve ya   .png ola biler!");
                    return View();
                }

                if (setting.AboutBannerImageFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                    return View();
                }


                string newFileName = FileManager.Save(_env.WebRootPath, "assets/img", setting.AboutBannerImageFile);

                if (!string.IsNullOrWhiteSpace(existData.AboutBannerImage))
                {
                    string oldFilePath = Path.Combine(_env.WebRootPath, "assets/img", existData.AboutBannerImage);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }


                existData.AboutBannerImage = newFileName;
            }
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
