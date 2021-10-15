using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:70)]
        public string ImageName { get; set; }
    }
}
