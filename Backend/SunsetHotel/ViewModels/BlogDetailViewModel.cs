using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class BlogDetailViewModel
    {
        public List<BlogCategory> blogCategories { get; set; }
        public List<Tag> tags { get; set; }
        public List<Blog> recentPost { get; set; }
        public Blog blog { get; set; }
    }
}
