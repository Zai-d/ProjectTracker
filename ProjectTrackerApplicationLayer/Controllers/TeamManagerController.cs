using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class TeamManagerController : Controller
    {
        
        private readonly ITeamManagerRepository teamManagerRepo;
        public TeamManagerController(ITeamManagerRepository teamManagerRepo)
        {
            this.teamManagerRepo = teamManagerRepo;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult NewTeamManagerForm()//New Team Manager form
        {
            return View();
        }

        //Adding function
        [Authorize(Roles = "Admin")]
        public IActionResult AddingTeamManager(UserDTO Manager)
        {
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", Manager.FirstName, Manager.LastName);
                var teamManager = new TeamManager()
                {
                    UserName = fullName,
                    Email = Manager.Email,
                    FirstName = Manager.FirstName,
                    LastName = Manager.LastName,
                    DateOfBirth = Manager.DateOfBirth,
                    PhoneNo = Manager.PhoneNo,
                    PositionID = 1,
                    EmailConfirmed = true,
                };
                var pass = teamManagerRepo.AddTeamManager(teamManager, Manager.Password, "2", 1);
                if (!pass.Succeeded)
                {
                    foreach (var Error in pass.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View("NewTeamManagerForm", Manager);
                }
                else
                {
                    return RedirectToAction("AllTeamManagers");
                }
            }
            else
            {
                return View("NewTeamManagerForm", Manager);
            }
        }

        //Full list view
        [Authorize(Roles = "Admin")]
        public IActionResult AllTeamManagers()
        {
            var teamManagers = teamManagerRepo.GetAllTeamManagers();

            return View(teamManagers);
        }

        //deleting function
        //[authorize(roles = "admin")]
        //public iactionresult deletemanager(string managerid)
        //{
        //    teammanagerrepo.deleteteammanager(teammanagerrepo.getteammanager(managerid));

        //    return redirecttoaction("allteammanagers");
        //}

        //Edit manager form

        [Authorize(Roles ="Admin")]
        public IActionResult EditManagerForm(string ManagerID)
        {
            var teamManager = teamManagerRepo.GetTeamManager(ManagerID);

            var teamManagerToEdit = new UserDTO()
            {
                UserID = ManagerID,
                Email = teamManager.Email,
                DateOfBirth = teamManager.DateOfBirth,
                FirstName = teamManager.FirstName,
                LastName = teamManager.LastName,
                PhoneNo = teamManager.PhoneNo,
                PositionID = teamManager.PositionID
            };

            return View(teamManagerToEdit);
        }

        //Edit manager function
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EdittingTeamManager(UserDTO EdittedManager)
        {
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Password");
             if (ModelState.IsValid)
             {
                var fullName = String.Join(" ", EdittedManager.FirstName, EdittedManager.LastName);
                var edittedManager = new TeamManager()
                {
                    Id = EdittedManager.UserID,
                    UserName = fullName,
                    Email = EdittedManager.Email,
                    FirstName = EdittedManager.FirstName,
                    LastName = EdittedManager.LastName,
                    DateOfBirth = EdittedManager.DateOfBirth,
                    PhoneNo = EdittedManager.PhoneNo,
                };
                var result = await teamManagerRepo.UpdateManager(edittedManager, edittedManager.Id);
                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamManagers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("EditManagerForm", EdittedManager);
                }

             }
            else
            {
                return View("EditManagerForm", EdittedManager);
            }
        }

        //Changing Password Form
        [Authorize(Roles = "Admin")]
        public IActionResult ChangePasswordForm(string ManagerID)
        {
            var manager = teamManagerRepo.GetTeamManager(ManagerID);
            var managerNewPass = new ChangePasswordDTO()
            {
                UserID = manager.Id,
                FullName = manager.UserName,
                Email = manager.Email,
            };
            return View(managerNewPass);
        }
        //Changing password fucntion
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangingPassword(ChangePasswordDTO newPasswordManager)
        {
            if (ModelState.IsValid)
            {
                var result = await teamManagerRepo.PasswordUpdate(newPasswordManager.UserID, newPasswordManager.OldPassword, newPasswordManager.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamManagers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("ChangePasswordForm", newPasswordManager);
                }
            }
            else
            {
                return View("ChangePasswordForm", newPasswordManager);
            }
        }
        public async Task<IActionResult> EnableManager(string managerID)
        {
            await teamManagerRepo.EnableManager(managerID);
            return RedirectToAction("AllTeamManagers");
        }
        public async Task<IActionResult> DisableManager(string managerID)
        {
            await teamManagerRepo.DisableManager(managerID);
            return RedirectToAction("AllTeamManagers");
        }
    }
}
