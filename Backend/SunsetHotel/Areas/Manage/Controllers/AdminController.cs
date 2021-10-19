using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunsetHotel.Areas.Manage.ViewModels;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.AppUsers.Where(x => x.IsAdmin == true).Count() / 8d);
            if (page > ViewBag.TotalPage)
            {
                return RedirectToAction("error", "dashboard");
            }
            var listado = await (from user in _context.AppUsers.Where(x => x.IsAdmin).Skip((page - 1) * 8).Take(8)
                                 join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                                 join role in _context.Roles on userRoles.RoleId equals role.Id

                                 select new AdminViewModel { UserId = user.Id, UserName = user.UserName, RoleId = role.Id, RoleName = role.Name })
                        .ToListAsync();

            return View(listado);
        }
        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles.Where(x => x.Name != "Member").ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdminViewModel createAdminVm)
        {
            ViewBag.Roles = _roleManager.Roles.Where(x => x.Name != "Member").ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_userManager.Users.Any(x => x.NormalizedUserName == createAdminVm.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }
            AppUser appUser = new AppUser
            {
                UserName = createAdminVm.UserName,
                IsAdmin = true
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, createAdminVm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            IdentityResult result1 = await _userManager.AddToRoleAsync(appUser, createAdminVm.Role);
            if (!result1.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Roles = _roleManager.Roles.Where(x => x.Name != "Member").ToList();
            AppUser existuser = await _userManager.FindByIdAsync(id);
            if (existuser == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            AddAdminUpdateViewModel updateVm = new AddAdminUpdateViewModel
            {
                UserName = existuser.UserName,
                Role = (await _userManager.GetRolesAsync(existuser)).First(),
                UserId = existuser.Id
            };
            return View(updateVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddAdminUpdateViewModel updateVM)
        {
            ViewBag.Roles = _roleManager.Roles.Where(x => x.Name != "Member").ToList();

            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByIdAsync(updateVM.UserId);

            if (user.UserName != updateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == updateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View(updateVM);
            }



            if (!string.IsNullOrWhiteSpace(updateVM.Password))
            {
                var tokenString = _userManager.GeneratePasswordResetTokenAsync(user).Result;

                var result = _userManager.ResetPasswordAsync(user, tokenString, updateVM.Password).Result;

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }

            }
            var roles = _userManager.GetRolesAsync(user).Result;
            if (updateVM.Role != null)
            {
                var result1 = _userManager.RemoveFromRolesAsync(user, roles).Result;
                if (!result1.Succeeded)
                {
                    foreach (var item in result1.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                var result2 = await _userManager.AddToRoleAsync(user, updateVM.Role);
            }

            user.UserName = updateVM.UserName;
            var updateResult = _userManager.UpdateAsync(user).Result;

            return RedirectToAction("index", "admin");
        }
        public async Task<IActionResult> Delete(string Id)
        {
            AppUser existUser = await _userManager.FindByIdAsync(Id);
            if (existUser == null)
            {
                return RedirectToAction("error", "dashboard");
            }
            var result = _userManager.DeleteAsync(existUser).Result;
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return Json(new { status = 200 });
        }
    }
}
