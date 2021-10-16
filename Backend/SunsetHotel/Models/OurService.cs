using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class OurService
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Desc { get; set; }
    }
}
