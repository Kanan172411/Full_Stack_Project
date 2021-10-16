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
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            TempData["forSelect"] = 3;
            double pageCount = Math.Ceiling(_context.Rooms.Count() / 4d);
            if (page > pageCount)
            {
                return RedirectToAction("error", "home");
            }
            ViewBag.TotalPage = pageCount;
            ViewBag.SelectedPage = page;

            Setting setting = _context.Settings.FirstOrDefault();

            ViewBag.WelcomeContent = setting.RoomWelcomeContent;
            ViewBag.Categories = _context.RoomCategories.ToList();
            RoomViewModel roomVM = new RoomViewModel
            {
                rooms = _context.Rooms.Include(x=>x.RoomImages).Include(x => x.Categories).Include(x =>x.RoomFeatureRelations).ThenInclude(x =>x.RoomFeature).Skip((page - 1) * 4).Take(4).ToList().ToList()
            };
            return View(roomVM);
        }

        public IActionResult Details(int id)
        {
            Room room = _context.Rooms.Where(x => x.Id == id).FirstOrDefault();
            if (room==null)
            {
                return RedirectToAction("error", "home");
            }
            RoomDetailsViewModel roomDetailsVm = new RoomDetailsViewModel
            {
                similiarRooms = _context.Rooms.Where(x => x.RoomCategoryId == room.RoomCategoryId && x.Id != id).Include(x=>x.RoomImages).ToList(),
                setting = _context.Settings.FirstOrDefault(),
                room = _context.Rooms
                .Where(x => x.Id == id)
                .Include(x => x.RoomImages)
                .Include(x => x.Categories)
                .Include(x => x.RoomFeatureRelations)
                .ThenInclude(x => x.RoomFeature)
                .FirstOrDefault()
            };
            return View(roomDetailsVm);
        }

        public IActionResult Reservation(int id)
        {
            Room room = _context.Rooms.Where(x => x.Id == id).Include(x => x.RoomImages).FirstOrDefault();
            if (room==null)
            {
                return RedirectToAction("error", "home");
            }
            ViewBag.Setting = _context.Settings.FirstOrDefault();
            return View(room);
        }

        public IActionResult MyReservation()
        {
            return View();
        } 
    }
}
