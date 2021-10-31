using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SunsetHotel.Areas.Manage.ViewModels;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = await _userManager.FindByNameAsync(loginVM.UserName);

            if (admin == null || !admin.IsAdmin)
            {
                ModelState.AddModelError("", "UserName ve ya sifre yanlsidir!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName ve ya sifre yanlsidir!");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            AdminUpdateViewModel updateModel = new AdminUpdateViewModel
            {
                UserName = user.UserName
            };

            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit(AdminUpdateViewModel updateVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.UserName != updateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == updateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }

            if (!string.IsNullOrWhiteSpace(updateVM.Password))
            {
                if (updateVM.Password != updateVM.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassowrd", "Password ve Confirm password eyni olmalidir!");
                    return View();
                }
                if (updateVM.CurrentPassword == null)
                {
                    ModelState.AddModelError("CurrentPassword", "Passwordu dəyişmək üçün hal-hazırkı password daxil edilməlidir!");
                    return View();
                }
                var result = await _userManager.ChangePasswordAsync(user, updateVM.CurrentPassword, updateVM.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            user.UserName = updateVM.UserName;
            await _userManager.UpdateAsync(user);
            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("index", "dashboard");
        }

        #region CreateAdmin
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        UserName = "SuperKenan",
        //        IsAdmin = true
        //    };
        //    await _userManager.CreateAsync(appUser, "admin123");
        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
        //    return Ok();
        //}
        #endregion
    }
}
