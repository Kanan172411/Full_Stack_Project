using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.ViewModels
{
    public class DashBoardViewModel
    {
        public List<BlogViewViewModel> radialChart { get; set; }
        public List<BlogCategoryViewModel> blogCategory{ get; set; }
        public List<ReservationCategoryViewModel> reservationByCategory { get; set; }
    }
}
