using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTrackerApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ProjectTrackerBusinessLayer.Entities;
using System.Threading.Tasks;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository IUserRepo;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, IUserRepository IUserRepo, SignInManager<User> signInManager, UserManager<User> _userManager)
        {
            this.IUserRepo = IUserRepo;
            _logger = logger;
            this.signInManager = signInManager;
            this._userManager = _userManager;
        }

        public IActionResult Index()
        {
            if (!signInManager.IsSignedIn(User))
            {
                if (IUserRepo.AllUsers().Count == 0)
                {
                    ViewBag.Count = IUserRepo.AllUsers().Count;
                    return View();
                }
                else
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }
            }
            else
            {
                return View("EmptyPage");

                //var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                //switch (user.PositionID)
                //{
                //    case 1:
                //        {
                //            return RedirectToAction(controllerName: "DashBoard", actionName: "ManagerDashBoard");
                //        }
                //    case 2:
                //        {
                //            return RedirectToAction(controllerName: "DashBoard", actionName: "LeaderDashBoard");
                //        }
                //    case 3:
                //    case 4:
                //        {
                //            return RedirectToAction(controllerName: "DashBoard", actionName: "MemberDashBoard");
                //        }
                //    case 5:
                //        {
                //            return RedirectToAction(controllerName: "DashBoard", actionName: "AdminDashBoard");
                //        }
                //    default:
                //        return View("EmptyPage");

                //}
            }
        }

        public IActionResult FirstTimeAdmin(UserDTO Admin)
        {
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", Admin.FirstName, Admin.LastName);
                var admin = new User()
                {
                    UserName = fullName,
                    Email = Admin.Email,
                    FirstName = Admin.FirstName,
                    LastName = Admin.LastName,
                    DateOfBirth = Admin.DateOfBirth,
                    PhoneNo = Admin.PhoneNo,
                    PositionID = 5,
                    EmailConfirmed = true,
                };
                var pass = IUserRepo.AddingAdmin(admin, Admin.Password);
                if (pass.Succeeded)
                {
                    return RedirectToAction(controllerName:"DashBoard", actionName: "AdminDashBoard");
                }
                else
                {
                    foreach (var Error in pass.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    ViewBag.Count = IUserRepo.AllUsers().Count;
                    return View("Index", Admin);
                }
            }
            else
            {
                ViewBag.Count = IUserRepo.AllUsers().Count;
                return View("Index", Admin);
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return base.View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
