using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 300)]
        public string Text { get; set; }
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [StringLength(maximumLength: 60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int BlogId { get; set; }
        public Blog blog { get; set; }
    }
}
