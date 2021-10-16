using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.ViewModels
{
    public class AboutViewModel
    {
        public Setting setting { get; set; }
        public List<OurService> ourServices1{ get; set; }
        public List<OurService> ourServices2 { get; set; }
        public List<Testimonial> testimonials { get; set; }
    }
}
