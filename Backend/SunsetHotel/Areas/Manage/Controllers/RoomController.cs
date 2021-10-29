using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using SunsetHotel.Helpers;
using SunsetHotel.Models;
using SunsetHotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailService _emailService;
        private readonly IHubContext<SunsetHub> _hubContext;
        public RoomController(AppDbContext context, IWebHostEnvironment env, IEmailService emailService, IHubContext<SunsetHub> hubContext)
        {
            _context = context;
            _env = env;
            _emailService = emailService;
            _hubContext = hubContext;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Rooms.Count() / 6d);
            List<Room> rooms = _context.Rooms.Include(x=>x.reservations).Include(x=>x.Comments).Include(x => x.RoomImages).Include(x=>x.Categories).Skip((page - 1) * 6).Take(6).ToList();
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
            if (_context.Rooms.Any(x => x.Code.ToLower() == room.Code.ToLower())) 
            {
                ModelState.AddModelError("Code", "This code already taken");
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
                foreach (var item in room.FeatureId)
                {
                    if (_context.RoomFeatures.All(x=>x.Id!=item))
                    {
                        ModelState.AddModelError("FeatureId","Featureləri düzgün daxil edin");
                        return View();
                    }
                }
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
                return View(existRoom);
            }
            if (_context.Rooms.Where(x => x.Id != room.Id).Any(x => x.Code.ToLower() == room.Code.ToLower())) 
            {
                ModelState.AddModelError("Code", "This code already taken");
                return View(existRoom);
            }

            if (room.FeatureId != null)
            {
                foreach (var item in room.FeatureId)
                {
                    if (_context.RoomFeatures.All(x => x.Id != item))
                    {
                        ModelState.AddModelError("FeatureId", "Featureləri düzgün daxil edin");
                        return View(existRoom);
                    }
                }
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
            }
            if (room.Images != null)
                {
                 foreach (var item in room.Images)
                 {
                     if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                     {
                         ModelState.AddModelError("Images", "Fayl   .jpg ve ya   .png ola biler!");
                         return View(existRoom);
                     }

                     if (item.Length > 2097152)
                     {
                         ModelState.AddModelError("Images", "Fayl olcusu 2mb-dan boyuk ola bilmez!");
                         return View(existRoom);
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
            if (room.Images == null && existRoom.RoomImages.Count == 0)
            {
                ModelState.AddModelError("Images", "Image yuklemek mecburidir!");
                return View(existRoom);
            }
            existRoom.Code = room.Code;
            existRoom.Name = room.Name;
            existRoom.Price = room.Price;
            existRoom.Desc = room.Desc;
            existRoom.RoomCategoryId = room.RoomCategoryId;
            existRoom.MaxAdult = room.MaxAdult;
            existRoom.MaxChild = room.MaxChild;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult DeleteImage(int Id, string Name, int RoomId)
        {
            Room room = _context.Rooms.Include(x=>x.RoomImages).Where(x => x.Id == RoomId).FirstOrDefault();
            if (room==null)
            {
                return NotFound();
            }
            RoomImage roomImage = _context.RoomImages.Where(x => x.RoomId == RoomId && x.Id == Id).FirstOrDefault();
            if (roomImage == null)
            {
                return NotFound();
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

        public IActionResult Comment(int id, int page = 1)
        {
            Room room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            if (room == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.RoomComments.Where(x => x.RoomId == id).Count() / 8d);
            ViewBag.Id = id;

            List<RoomComment> comments = _context.RoomComments.Where(x => x.RoomId == room.Id).Skip((page - 1) * 8).Take(8).ToList();
            return View(comments);
        }
        public IActionResult DeleteComment(int id)
        {
            RoomComment roomComment = _context.RoomComments.FirstOrDefault(x => x.Id == id);
            if (roomComment == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            _context.RoomComments.Remove(roomComment);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
        public IActionResult Reservation(int id, int page = 1)
        {
            Room room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            if (room == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.Reservations.Where(x => x.RoomId == id).Count() / 8d);
            ViewBag.Id = id;

            List<Reservation> reservations = _context.Reservations.Include(x=>x.appUser).Include(x=>x.room).Where(x => x.RoomId == room.Id).Skip((page - 1) * 8).Take(8).ToList();
            return View(reservations);
        }
        public IActionResult ReservationDetail(int id)
        {
            Reservation reservation = _context.Reservations.Include(x=>x.appUser).Include(x=>x.room).Where(x => x.Id == id).FirstOrDefault();
            if (reservation==null)
            {
                return RedirectToAction("error", "dashboard");
            }
            ViewBag.Id = reservation.RoomId;
            return View(reservation);
        }
        public async Task<IActionResult> Accept(int id, string note)
        {
            Reservation reservation = _context.Reservations.Include(x => x.room).Include(x => x.appUser).FirstOrDefault(x => x.Id == id);

            if (reservation == null) return Json(new { status = 402 });
            if (reservation.Status != null) return Json(new { status = 402 });

            reservation.Status = true;
            reservation.AdminNote = note;

            _context.SaveChanges();

            if (reservation.appUser.ConnectionId != null)
            {
                await _hubContext.Clients.Client(reservation.appUser.ConnectionId).SendAsync("OrderAccept");
            }
            if (note == null)
            {
                _emailService.Send(reservation.appUser.Email, @"Reservation Accepted", "<br />" +
                     "Room: " + reservation.room.Name + "<br />" +
                     "Price: " + $"{reservation.room.Price * reservation.NightCount + reservation.NightCount * 5}" + "<br />" +
                     "Check-in: " + reservation.CheckIn.ToString("dd-MM-yyyy") + "<br />" +
                     "Check-out: " + reservation.CheckOut.ToString("dd-MM-yyyy"));
            }
            else
            {
                _emailService.Send(reservation.appUser.Email, @"Reservation Accepted", "<br />" +
                     "Room: " + reservation.room.Name + "<br />" +
                     "Price: " + $"{reservation.room.Price * reservation.NightCount + reservation.NightCount * 5}" + "<br />" +
                     "Check-in: " + reservation.CheckIn.ToString("dd-MM-yyyy") + "<br />" +
                     "Check-out: " + reservation.CheckOut.ToString("dd-MM-yyyy") + "<br/>"+
                     "Admin note: "+ note);
            }           
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Reject(int id, string note)
        {
            Reservation reservation = _context.Reservations.Include(x => x.appUser).Include(x => x.room).FirstOrDefault(x => x.Id == id);

            if (reservation == null)
            {
                return Json(new { status = 402 });
            }
            if (reservation.Status != null) return Json(new { status = 404 });
            if (string.IsNullOrWhiteSpace(note))
            {
                return Json(new { status = 402 });
            }

            reservation.Status = false;
            reservation.AdminNote = note;
            if (reservation.appUser.ConnectionId != null)
            {
                await _hubContext.Clients.Client(reservation.appUser.ConnectionId).SendAsync("OrderReject");
            }
            _context.SaveChanges();
            _emailService.Send(reservation.appUser.Email, @"Reservation Rejected", "<br />" +
             "Room: " + reservation.room.Name + "<br />" +
             "Check-in: " + reservation.CheckIn.ToString("dd-MM-yyyy") + "<br />" +
             "Check-out: " + reservation.CheckOut.ToString("dd-MM-yyyy") + "<br/>" +
             "Admin note: " + note);
            return Json(new { status = 200 });
        }
    }
}
