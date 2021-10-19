using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class ReservationViewModel
    {
        public Room room { get; set; }
        public AppUser appUser { get; set; }
        public Reservation reservation { get; set; }
    }
}
