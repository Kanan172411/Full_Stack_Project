using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using SunsetHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            TempData["forSelect"] = 1;
            HomeViewModel homeVM = new HomeViewModel
            {
                setting = _context.Settings.FirstOrDefault(),
                rooms1 = _context.Rooms.Include(x => x.RoomImages).Take(2).ToList(),
                rooms2 = _context.Rooms.Include(x => x.RoomImages).Skip(2).Take(2).ToList(),
                features = _context.Features.ToList(),
                galleries = _context.Galleries.ToList(),
                testimonials = _context.Testimonials.ToList(),
                blogs1 = _context.Blogs.Take(3).ToList(),
                blogs2 = _context.Blogs.Skip(3).Take(3).ToList(),
            };

            return View(homeVM);
        }

        public IActionResult Contact()
        {
            TempData["forSelect"] = 5;

            Setting setting = _context.Settings.FirstOrDefault();

            return View(setting);
        }
        
        public IActionResult About()
        {
            TempData["forSelect"] = 2;

            AboutViewModel aboutVM = new AboutViewModel
            {
                setting = _context.Settings.FirstOrDefault(),
                ourServices1 = _context.OurServices.Take(2).ToList(),
                ourServices2 = _context.OurServices.Skip(2).Take(2).ToList(),
                testimonials = _context.Testimonials.ToList()
            };

            return View(aboutVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(Subscriber subscriber)
        {
            if (subscriber.Email.Length>49)
            {
                TempData["Alert"] = "Email uzunluğu maksimum 50 xarakterdir";
                TempData["Type"] = "danger";
                return RedirectToAction("index");
            }
            if (subscriber.Email.Trim().EndsWith("."))
            {
                TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                TempData["Type"] = "danger";
                return RedirectToAction("index");
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(subscriber.Email);
            }
            catch
            {
                TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                TempData["Type"] = "danger";
                return RedirectToAction("index");
            }
            if (_context.Subscribers.Any(x => x.Email == subscriber.Email))
            {
                TempData["Alert"] = "Bu email artiq abune olub";
                TempData["Type"] = "danger";
                return RedirectToAction("index");
            }
            Subscriber subscriber1 = new Subscriber
            {
                Email = subscriber.Email
            };
            TempData["Alert"] = "Successfully subscribed";
            TempData["Type"] = "success";
            _context.Add(subscriber1);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(ContactMessages contactMessages, int id)
        {
            if (id==1)
            {
                if (contactMessages.Message == null || string.IsNullOrWhiteSpace(contactMessages.Message) || contactMessages.Message.Length < 15)
                {
                    TempData["Alert"] = "Message must be more than 15 character";
                    TempData["Type"] = "danger";
                    return RedirectToAction("contact", "home");
                }
                if (contactMessages.Message.Length > 299)
                {
                    TempData["Alert"] = "Message must be less than 300 character";
                    TempData["Type"] = "danger";
                    return RedirectToAction("contact", "home");
                }

                ContactMessages contactMessages1 = new ContactMessages();

                if (!User.Identity.IsAuthenticated || User.IsInRole("Member") == false)
                {
                    if (contactMessages.Name == null || string.IsNullOrWhiteSpace(contactMessages.Name))
                    {
                        TempData["Alert"] = "Name required";
                        TempData["Type"] = "danger";
                        return RedirectToAction("contact", "home");
                    }
                    if (contactMessages.Email == null || string.IsNullOrWhiteSpace(contactMessages.Email))
                    {
                        TempData["Alert"] = "Email required";
                        TempData["Type"] = "danger";
                        return RedirectToAction("contact", "home");
                    }
                    if (contactMessages.Email.Trim().EndsWith("."))
                    {
                        TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                        TempData["Type"] = "danger";
                        return RedirectToAction("contact", "home");
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(contactMessages.Email);
                    }
                    catch
                    {
                        TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                        TempData["Type"] = "danger";
                        return RedirectToAction("contact");
                    }
                    contactMessages1.Name = contactMessages.Name;
                    contactMessages1.Email = contactMessages.Email;
                }
                else
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    contactMessages1.Email = user.Email;
                    contactMessages1.Name = user.FullName;
                }
                contactMessages1.Message = contactMessages.Message;
                contactMessages1.SendedAt = DateTime.UtcNow;
                _context.ContactMessages.Add(contactMessages1);
                _context.SaveChanges();
                TempData["Alert"] = "Successfully sended";
                TempData["Type"] = "success";
                return RedirectToAction("contact", "home");
            }
            else
            {
                if (contactMessages.Message == null || string.IsNullOrWhiteSpace(contactMessages.Message) || contactMessages.Message.Length < 15)
                {
                    TempData["Alert"] = "Message must be more than 15 character";
                    TempData["Type"] = "danger";
                    return RedirectToAction("index", "home");
                }
                if (contactMessages.Message.Length > 299)
                {
                    TempData["Alert"] = "Message must be less than 300 character";
                    TempData["Type"] = "danger";
                    return RedirectToAction("index", "home");
                }

                ContactMessages contactMessages1 = new ContactMessages();
                if (!User.Identity.IsAuthenticated || User.IsInRole("Member") == false)
                {
                    if (contactMessages.Name == null || string.IsNullOrWhiteSpace(contactMessages.Name))
                    {
                        TempData["Alert"] = "Name required";
                        TempData["Type"] = "danger";
                        return RedirectToAction("index", "home");
                    }
                    if (contactMessages.Email == null || string.IsNullOrWhiteSpace(contactMessages.Email))
                    {
                        TempData["Alert"] = "Email required";
                        TempData["Type"] = "danger";
                        return RedirectToAction("index", "home");
                    }
                    if (contactMessages.Email.Trim().EndsWith("."))
                    {
                        TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                        TempData["Type"] = "danger";
                        return RedirectToAction("index", "home");
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(contactMessages.Email);
                    }
                    catch
                    {
                        TempData["Alert"] = "Emaili düzgün formatda daxil edin";
                        TempData["Type"] = "danger";
                        return RedirectToAction("index","home");
                    }
                    contactMessages1.Name = contactMessages.Name;
                    contactMessages1.Email = contactMessages.Email;
                }
                else
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    contactMessages1.Email = user.Email;
                    contactMessages1.Name = user.FullName;
                }
                contactMessages1.Message = contactMessages.Message;
                contactMessages1.SendedAt = DateTime.UtcNow;
                _context.ContactMessages.Add(contactMessages1);
                _context.SaveChanges();
                TempData["Alert"] = "Successfully sended";
                TempData["Type"] = "success";
                return RedirectToAction("index", "home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
