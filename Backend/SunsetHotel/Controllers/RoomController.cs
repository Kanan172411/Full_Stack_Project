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
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RoomController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Reservation(int id)
        {
            Room room = _context.Rooms.Where(x => x.Id == id).Include(x => x.RoomImages).FirstOrDefault();
            if (room==null)
            {
                return RedirectToAction("error", "home");
            }

            List<Select> MaxChild = new List<Select>();
            for (int i = 1; i < room.MaxChild + 1; i++)
            {
                Select selectList = new Select
                {
                    Id = i,
                    Value = $"{i} Child"
                };
                MaxChild.Add(selectList);
            }
            ViewBag.MaxChild = MaxChild;

            List<Select> MaxAdult = new List<Select>();
            for (int i = 1; i < room.MaxAdult + 1; i++)
            {
                Select selectList = new Select
                {
                    Id = i,
                    Value = $"{i} Adult"
                };
                MaxAdult.Add(selectList);
            }
            ViewBag.MaxAdult = MaxAdult;

            AppUser appUser1 = await _userManager.FindByNameAsync(User.Identity.Name);
            ReservationViewModel reservationVM = new ReservationViewModel
            {
                room = _context.Rooms.Where(x => x.Id == id).Include(x => x.RoomImages).FirstOrDefault(),
                appUser = appUser1
            };
            ViewBag.UserId = appUser1.Id;
            ViewBag.Setting = _context.Settings.FirstOrDefault();
            return View(reservationVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reservation(Reservation reservation)
        {
            AppUser appUser1 = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = appUser1.Id;
            ViewBag.Setting = _context.Settings.FirstOrDefault();
            Room existroom = _context.Rooms.Include(x=>x.reservations).Include(x=>x.RoomImages).Where(x => x.Id == reservation.RoomId).FirstOrDefault();
            ReservationViewModel reservationViewModel = new ReservationViewModel
            {
                room = existroom,
                appUser = appUser1
            };

            #region Checking
            if (existroom == null)
            {
                return RedirectToAction("error", "home");
            }
            if (reservation.CheckIn<DateTime.UtcNow)
            {
                ModelState.AddModelError("reservation.CheckIn", "Keçmişə rezervasiya etmək mümkün deyil");
                return View(reservationViewModel);
            }
            if (reservation.CheckOut <= reservation.CheckIn)
            {
                ModelState.AddModelError("reservation.CheckOut", "Check-out tarixi Check-in tarixindən böyük olmalıdır");
                return View(reservationViewModel);
            }
            if (existroom.reservations.Any(x => x.CheckIn < reservation.CheckIn && x.CheckOut >= reservation.CheckIn)) 
            {
                ModelState.AddModelError("","Seçdiyiniz tarixlər üçün otaq artıq rezerv olunub");
                return View(reservationViewModel);
            }
            if (reservation.FullName==null)
            {
                ModelState.AddModelError("reservation.FullName", "This field is required");
                return View(reservationViewModel);
            }            
            
            if (reservation.Address==null)
            {
                ModelState.AddModelError("reservation.Address", "This field is required");
                return View(reservationViewModel);
            }            
            if (reservation.City==null)
            {
                ModelState.AddModelError("reservation.City", "This field is required");
                return View(reservationViewModel);
            }            
            if (reservation.Country==null)
            {
                ModelState.AddModelError("reservation.Country", "This field is required");
                return View(reservationViewModel);
            }            
            if (reservation.PhoneNumber==null)
            {
                ModelState.AddModelError("reservation.PhoneNumber", "This field is required");
                return View(reservationViewModel);
            }            
            if (reservation.Email==null)
            {
                ModelState.AddModelError("reservation.Email", "This field is required");
                return View(reservationViewModel);
            }
            #endregion
            List<Select> MaxChild = new List<Select>();
            for (int i = 1; i < existroom.MaxChild + 1; i++)
            {
                Select selectList = new Select
                {
                    Id = i,
                    Value = $"{i} Child"
                };
                MaxChild.Add(selectList);
            }
            ViewBag.MaxChild = MaxChild;

            List<Select> MaxAdult = new List<Select>();
            for (int i = 1; i < existroom.MaxAdult + 1; i++)
            {
                Select selectList = new Select
                {
                    Id = i,
                    Value = $"{i} Adult"
                };
                MaxAdult.Add(selectList);
            }
            ViewBag.MaxAdult = MaxAdult;
            ViewBag.MaxAdult = MaxAdult;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction("details", "room", new { id = reservation.RoomId });
        }

        public IActionResult MyReservation()
        {
            return View();
        } 
    }
}
