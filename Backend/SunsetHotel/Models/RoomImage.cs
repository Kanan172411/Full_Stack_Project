using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        [StringLength(maximumLength:70)]
        public string ImageName { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
