using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [Range(1,5)]
        public int StarCount { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Desc { get; set; }
    }
}
