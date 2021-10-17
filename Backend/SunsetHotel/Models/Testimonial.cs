using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string Profession { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Desc { get; set; }
        [StringLength(maximumLength:500)]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
