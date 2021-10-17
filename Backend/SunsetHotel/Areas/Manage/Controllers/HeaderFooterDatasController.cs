using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    public class HeaderFooterDatasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
