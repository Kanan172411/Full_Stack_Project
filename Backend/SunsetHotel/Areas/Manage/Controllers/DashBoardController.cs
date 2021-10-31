using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.Areas.Manage.ViewModels;
using SunsetHotel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int monthly = 0;
            foreach (var item in _context.Reservations.Include(x => x.room).Where(x => x.Status == true && x.CheckIn >= DateTime.Now.AddMonths(-1) && x.CheckOut <= DateTime.Now))
            {
                monthly += item.NightCount * item.room.Price;
            }
            ViewBag.monthly = monthly;

            int annual = 0;
            foreach (var item in _context.Reservations.Include(x => x.room).Where(x => x.Status == true && x.CheckIn >= DateTime.Now.AddYears(-1) && x.CheckOut <= DateTime.Now))
            {
                annual += item.NightCount * item.room.Price;
            }
            ViewBag.Annual = annual;

            double allBooking = _context.Reservations.Count();
            double acceptedBooking = _context.Reservations.Where(x => x.Status == true).Count();
            ViewBag.AcceptedPercent = (int)acceptedBooking * 100 / (int)allBooking;
            ViewBag.Pending = _context.Reservations.Where(x => x.Status == null).Count();

            int BlogCount = 0;
            foreach (var item in _context.Blogs)
            {
                BlogCount += item.ViewsCount;
            }
            ViewBag.BlogCount = BlogCount;
            List<BlogViewViewModel> radialChartViewModels = new List<BlogViewViewModel>();
            foreach (var item in _context.BlogCategories.Include(x=>x.Blogs))
            {
                int SerieCount = 0;
                foreach (var item1 in item.Blogs)
                {
                    SerieCount += item1.ViewsCount;
                }
                radialChartViewModels.Add(new BlogViewViewModel
                {
                    Labels = SerieCount*100/BlogCount,
                    Series = item.Name

                });
            }

            List<BlogCategoryViewModel> blogCategoryViewModels = new List<BlogCategoryViewModel>();
            foreach (var item in _context.BlogCategories.Include(x=>x.Blogs))
            {
                blogCategoryViewModels.Add(new BlogCategoryViewModel
                {
                    Labels = item.Blogs.Count(),
                    Series = item.Name
                });
            }
            List<ReservationCategoryViewModel> reservationCategoryViewModels = new List<ReservationCategoryViewModel>();
            foreach (var item in _context.RoomCategories.Include(x=>x.Rooms).ThenInclude(x=>x.reservations))
            {
                int ReservationCont = 0;
                foreach (var item1 in item.Rooms)
                {
                    foreach (var item2 in item1.reservations)
                    {
                        if (item2.Status == true && item2.CheckOut < DateTime.Now)
                        {
                            ReservationCont += item2.NightCount * item1.Price;
                        }
                    }
                }
                reservationCategoryViewModels.Add(new ReservationCategoryViewModel
                {
                    Series = item.Name,
                    Labels = ReservationCont
                });
            }
            List<RoomCategoryViewModel> roomCategoryViewModels = new List<RoomCategoryViewModel>();
            foreach (var item in _context.RoomCategories.Include(x=>x.Rooms))
            {
                roomCategoryViewModels.Add(new RoomCategoryViewModel
                {
                    Labels = item.Rooms.Count(),
                    Series = item.Name
                }); 
            }
            DashBoardViewModel dashBoardViewModel = new DashBoardViewModel()
            {
                radialChart = radialChartViewModels,
                blogCategory = blogCategoryViewModels,
                reservationByCategory = reservationCategoryViewModels,
                roomCatCount = roomCategoryViewModels
            };
 
            return View(dashBoardViewModel);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
