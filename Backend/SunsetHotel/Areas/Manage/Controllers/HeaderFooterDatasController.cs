using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class HeaderFooterDatasController : Controller
    {
        private readonly AppDbContext _context;
        public HeaderFooterDatasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HeaderFooterData headerFooterData = _context.HeaderFooterDatas.FirstOrDefault();
            return View(headerFooterData);
        }
        public IActionResult Edit(int id)
        {
            HeaderFooterData headerFooterData = _context.HeaderFooterDatas.FirstOrDefault(x=>x.Id==id);

            if (headerFooterData == null) return RedirectToAction("error", "dashboard");

            return View(headerFooterData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HeaderFooterData headerFooterData)
        {
            HeaderFooterData existData = _context.HeaderFooterDatas.FirstOrDefault(x => x.Id == headerFooterData.Id);

            if (existData == null) return RedirectToAction("error", "dashboard");
            existData.Location = headerFooterData.Location;
            existData.LogoPart1 = headerFooterData.LogoPart1;
            existData.LogoPart2 = headerFooterData.LogoPart2;
            existData.Number = headerFooterData.Number;
            existData.Google = headerFooterData.Google;
            existData.Twitter = headerFooterData.Twitter;
            existData.Facebook = headerFooterData.Facebook;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
