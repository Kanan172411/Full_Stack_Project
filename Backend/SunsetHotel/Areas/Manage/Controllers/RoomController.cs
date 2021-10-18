using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public RoomController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Rooms.Count() / 6d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            List<Room> rooms = _context.Rooms.Include(x => x.RoomImages).Include(x=>x.Categories).Skip((page - 1) * 6).Take(6).ToList();
            return View(rooms);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.RoomCategories.ToList();
            ViewBag.Features = _context.RoomFeatures.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            ViewBag.Categories = _context.RoomCategories.ToList();
            ViewBag.Features = _context.RoomFeatures.ToList();

            if (!ModelState.IsValid) return View();

            if (!_context.RoomCategories.Any(x => x.Id == room.RoomCategoryId))
            {
                ModelState.AddModelError("RoomCategoryId", "Kateqoriya mövcud deyil!");
                return View();
            }

            if (room.Images != null)
            {
                foreach (var item in room.Images)
                {
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError("Images", "Fayl   .jpg ve ya   .png ola biler!");
                        return View();
                    }

                    if (item.Length > 3145728)
                    {
                        ModelState.AddModelError("Images", "Fayl olcusu 3mb-dan boyuk ola bilmez!");
                        return View();
                    }

                }
            }
            else
            {
                ModelState.AddModelError("Images", "Image yuklemek mecburidir!");
                return View();
            }

            room.RoomImages = new List<RoomImage>();


            if (room.Images != null)
            {
                foreach (var item in room.Images)
                {
                    RoomImage roomImage = new RoomImage
                    {
                        ImageName = FileManager.Save(_env.WebRootPath, "assets/img", item)
                    };
                    room.RoomImages.Add(roomImage);
                }
            }

            room.RoomFeatureRelations = new List<RoomFeatureRelation>();
            if (room.FeatureId != null)
            {
                foreach (var featureId in room.FeatureId)
                {
                    RoomFeatureRelation roomFeature = new RoomFeatureRelation
                    {
                        RoomFeatureId = featureId
                    };
                    room.RoomFeatureRelations.Add(roomFeature);
                }
            }

            _context.Rooms.Add(room);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Room room = _context.Rooms.Include(x => x.RoomImages).Include(x => x.Categories).Include(x=>x.RoomFeatureRelations).ThenInclude(x=>x.RoomFeature).FirstOrDefault(x => x.Id == id);
            if (room == null) return RedirectToAction("error","dashboard");

            room.FeatureId = room.RoomFeatureRelations.Select(x => x.RoomFeatureId).ToList();

            ViewBag.Categories = _context.RoomCategories.ToList();
            ViewBag.Features = _context.RoomFeatures.ToList();

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Categories = _context.RoomCategories.ToList();
            ViewBag.Features = _context.RoomFeatures.ToList();
            Room existRoom = _context.Rooms.Include(x=>x.RoomFeatureRelations).Include(x=>x.RoomImages).FirstOrDefault(x => x.Id == room.Id);

            if (existRoom == null) return RedirectToAction("error","dashboard");

            if (!_context.RoomCategories.Any(x => x.Id == room.RoomCategoryId))
            {
                ModelState.AddModelError("RoomCategoryId", "Kateqoriya mövcud deyil!");
                return View();
            }

            existRoom.Name = room.Name;
            existRoom.Price = room.Price;
            existRoom.Desc = room.Desc;
            existRoom.RoomCategoryId = room.RoomCategoryId;

            if (room.FeatureId != null)
            {
                existRoom.RoomFeatureRelations.RemoveAll(x => !room.FeatureId.Contains(x.RoomFeatureId));
                foreach (var item in room.FeatureId)
                {
                    RoomFeatureRelation roomFeature = existRoom.RoomFeatureRelations.FirstOrDefault(x => x.RoomFeatureId == item);

                    if (roomFeature == null)
                    {
                        roomFeature = new RoomFeatureRelation
                        {
                            RoomId = room.Id,
                            RoomFeatureId = item
                        };
                        existRoom.RoomFeatureRelations.Add(roomFeature);
                    }
                }
                if (room.Images != null)
                {
                    foreach (var item in room.Images)
                    {
                        if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                        {
                            ModelState.AddModelError("Images", "Fayl   .jpg ve ya   .png ola biler!");
                            return View();
                        }

                        if (item.Length > 2097152)
                        {
                            ModelState.AddModelError("Images", "Fayl olcusu 2mb-dan boyuk ola bilmez!");
                            return View();
                        }
                    }
                    foreach (var item1 in room.Images)
                    {
                       RoomImage roomImage = new RoomImage
                       {
                          ImageName = FileManager.Save(_env.WebRootPath, "assets/img", item1)
                       };
                       existRoom.RoomImages.Add(roomImage);
                    }
                }
            }

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult DeleteImage(int Id, string Name)
        {
            RoomImage roomImage = _context.RoomImages.Where(x => x.Id == Id).FirstOrDefault();
            if (roomImage==null)
            {
                return Json(new { status = 404 });
            }
            var a = FileManager.Delete(_env.WebRootPath, "assets/img", Name);
            if (!a)
            {
                return NotFound();
            }
            _context.RoomImages.Remove(roomImage);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }

        public IActionResult Delete(int id)
        {
            Room existRoom = _context.Rooms.Include(x => x.RoomImages).FirstOrDefault(x => x.Id == id);
            if (existRoom == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            foreach (var item in existRoom.RoomImages)
            {
                if (!string.IsNullOrWhiteSpace(item.ImageName))
                {
                   FileManager.Delete(_env.WebRootPath, "assets/img", item.ImageName);
                }

            }
            _context.Rooms.Remove(existRoom);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
