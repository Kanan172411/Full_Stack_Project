using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class RoomComment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string Text { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int RoomId { get; set; }
        public Room room { get; set; }
        public string AppUserId { get; set; }
        public AppUser appUser { get; set; }
    }
}
