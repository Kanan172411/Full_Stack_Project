using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class RoomDetailsViewModel
    {
        public List<Room> similiarRooms { get; set; }
        public Setting setting { get; set; }
        public Room room { get; set; }
    }
}
