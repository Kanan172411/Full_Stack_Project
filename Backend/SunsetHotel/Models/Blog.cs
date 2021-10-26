using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:120)]
        public string Name { get; set; }
        [StringLength(maximumLength: 70)]
        public string ImageName { get; set; }
        [Required]
        public DateTime Createdat { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Desc1 { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string DescHeader { get; set; }
        [Required]
        [StringLength(maximumLength: 1000)]
        public string Desc2 { get; set; }
        [Required]
        public int BlogCategoryId { get; set; }
        [Required]
        [StringLength(maximumLength: 80)]
        public string BlogPostTitle { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<BlogTag> BlogTags { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public List<int> TagId { get; set; }
        public List<BlogComment> Comments { get; set; }
        public int ViewsCount { get; set; }
    }
}
