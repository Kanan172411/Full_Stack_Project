using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string LogoPart1 { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string LogoPart2 { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string WelcomeContent { get; set; }
        [StringLength(maximumLength: 80)]
        public string AboutBannerImage { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string AboutTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string AboutDesc1 { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string AboutDesc2 { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string OurbestRoomsTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string OurGalleryTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string TestimonialsTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 60)]
        public string PhoneNumber1 { get; set; }
        [Required]
        [StringLength(maximumLength: 60)]
        public string PhoneNumber2 { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string AboutWelcomeContent { get; set; }
        [Required]
        [Range(0,10000)]
        public int GuestsStay { get; set; }
        [Required]
        [Range(0, 1000)]
        public int RoomsCount { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Awards { get; set; }
        [Required]
        [Range(0, 10000)]
        public int MealServed { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string OurServicesTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string AboutEndBannerText { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string ByWho { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string RoomWelcomeContent { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string BlogWelcomeContent { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string ContactUsWelcomeContent { get; set; } 
        [Required]
        [StringLength(maximumLength: 150)]
        public string ReservationWelcomeContent { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string ReservationTitle { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string InfoTitle { get; set; }
        [NotMapped]
        public IFormFile AboutBannerImageFile { get; set; }
    }
}
