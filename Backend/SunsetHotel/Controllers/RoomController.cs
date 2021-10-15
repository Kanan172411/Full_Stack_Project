using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            TempData["forSelect"] = 3;
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            return View();
        }

        public IActionResult MyReservation()
        {
            return View();
        } 
    }
}
