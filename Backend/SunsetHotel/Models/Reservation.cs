using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Range(0,5)]
        public int ChildCount { get; set; }
        [Required]
        [Range(1, 5)]
        public int AdultCount { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        [Required]
        [StringLength(maximumLength:70)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength:70)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }
        [Required]
        [StringLength(maximumLength: 60)]
        public string Country { get; set; }
        [StringLength(maximumLength: 500)]
        public string SpecialReq { get; set; }
        [StringLength(maximumLength: 300)]
        public string AdminNote { get; set; }
        public int NightCount { get; set; }
        public bool? Status { get; set; }
        public int RoomId { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public Room room { get; set; }
        public AppUser appUser { get; set; }
    }
}
