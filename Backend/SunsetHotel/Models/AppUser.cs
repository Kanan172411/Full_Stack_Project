using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class AppUser:IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ConnectionId { get; set; }
        public List<Reservation> reservations { get; set; }
        public List<RoomComment> Comments { get; set; }
    }
}
