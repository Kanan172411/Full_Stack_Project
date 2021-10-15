using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class RoomCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:40)]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
