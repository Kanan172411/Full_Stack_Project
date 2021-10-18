using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SunsetHotel.DAL;
using SunsetHotel.Models;
using SunsetHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel registerVM)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_userManager.Users.Any(x => x.NormalizedUserName == registerVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (_userManager.Users.Any(x => x.NormalizedEmail == registerVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }

            AppUser appUser = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                FullName = registerVM.FullName,
                IsAdmin = false
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, "Member");
            await _signInManager.SignInAsync(appUser, true);
            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);

            if (user == null || user.IsAdmin)
            {
                ModelState.AddModelError("", "UserName ve ya Sifre yanlisdir!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName ve ya Sifre yanlisdir!");
                return View();
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel updateModel = new UserUpdateViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
            };
            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateViewModel updateVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.UserName != updateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == updateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }

            if (user.Email != updateVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == updateVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View();
            }

            user.UserName = updateVM.UserName;
            user.Email = updateVM.Email;
            user.FullName = updateVM.FullName;
            user.City = updateVM.City;
            user.Country = updateVM.Country;
            user.PhoneNumber = updateVM.PhoneNumber;

            await _userManager.UpdateAsync(user);
            await _signInManager.SignInAsync(user, true);


            return RedirectToAction("index", "home");
        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!string.IsNullOrWhiteSpace(changePasswordVM.Password))
            {
                if (changePasswordVM.Password != changePasswordVM.ConfirmPassowrd)
                {
                    ModelState.AddModelError("ConfirmPassowrd", "Password ve Confirm password eyni olmalidir!");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, changePasswordVM.CurrentPassowrd, changePasswordVM.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }

            }
            return RedirectToAction("index", "home");
        }


        #region CreateRole
        //public async Task<IActionResult> Create()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Editor" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}
        #endregion
    }
}
