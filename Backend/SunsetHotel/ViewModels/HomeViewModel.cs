using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class HomeViewModel
    {
        public List<Room> rooms1 { get; set; }
        public List<Room> rooms2 { get; set; }
        public Setting setting { get; set; }
        public List<Feature> features { get; set; }
        public List<Gallery> galleries { get; set; }
        public List<Testimonial> testimonials { get; set; }
        public List<Blog> blogs1 { get; set; }
        public List<Blog> blogs2 { get; set; }
    }
}
