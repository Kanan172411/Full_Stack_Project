using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class ContactMessages
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string Message { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime SendedAt { get; set; }
    }
}
