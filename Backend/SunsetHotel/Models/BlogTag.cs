using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class BlogTag
    {
        public int Id { get; set; }
        [Required]
        public int TagId { get; set; }
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public Tag Tag { get; set; }
    }
}
