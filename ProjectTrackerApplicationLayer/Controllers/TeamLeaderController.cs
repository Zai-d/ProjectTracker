using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class TeamLeaderController : Controller
    {
        private readonly ITeamLeaderRepository teamLeaderRepo;
        public TeamLeaderController(ITeamLeaderRepository teamLeaderRepo)
        {
            this.teamLeaderRepo = teamLeaderRepo;
        
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AllTeamLeaders()//All Team Leaders
        {
            var teamLeaders = teamLeaderRepo.GetAllTeamLeaders();
            return View(teamLeaders);
        }

        //New Team Leader form
        [Authorize(Roles ="Admin")]
        public IActionResult NewTeamLeaderForm()
        {
            return View();
        }

        //Adding function
        [Authorize(Roles ="Admin")]
        public IActionResult AddingTeamLeader(UserDTO Leader)
        {
            //Leader.DateOfBirth.ToShortDateString().ToString();
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", Leader.FirstName, Leader.LastName);
                var teamLeader = new TeamLeader()
                {
                    UserName = fullName,
                    Email = Leader.Email,
                    FirstName = Leader.FirstName,
                    LastName = Leader.LastName,
                    DateOfBirth = Leader.DateOfBirth,
                    PhoneNo = Leader.PhoneNo,
                    PositionID = 2,
                    EmailConfirmed = true,
                };
                var pass = teamLeaderRepo.AddTeamLeader(teamLeader, Leader.Password, "3", 2);
                if (!pass.Succeeded)
                {
                    foreach (var Error in pass.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View("NewTeamLeaderForm", Leader);
                }
                else
                {
                    return RedirectToAction("AllTeamLeaders");
                }
            }
            else
            {
                return View("NewTeamLeaderForm", Leader);
            }

        }

        ////Deleting Function
        //[Authorize(Roles = "Admin")]
        //public IActionResult DeleteLeader(string LeaderID)
        //{
        //    teamLeaderRepo.DeleteTeamLeader(teamLeaderRepo.GetTeamLeader(LeaderID));
        //    return RedirectToAction("AllTeamLeaders");
        //}

        //Edit leader form

        [Authorize(Roles = "Admin")]
        public IActionResult EditLeaderForm(string LeaderID)
        {
            var teamLeader = teamLeaderRepo.GetTeamLeader(LeaderID);

            var teamLeaderToEdit = new UserDTO()
            {
                UserID = LeaderID,
                Email = teamLeader.Email,
                DateOfBirth = teamLeader.DateOfBirth,
                FirstName = teamLeader.FirstName,
                LastName = teamLeader.LastName,
                PhoneNo = teamLeader.PhoneNo,
                PositionID = teamLeader.PositionID
            };

            return View(teamLeaderToEdit);
        }

        //Edit leader function
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EdittingTeamLeader(UserDTO EdittedLeader)
        {
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", EdittedLeader.FirstName, EdittedLeader.LastName);
                var edittedLeader = new TeamLeader()
                {
                    Id = EdittedLeader.UserID,
                    UserName = fullName,
                    Email = EdittedLeader.Email,
                    FirstName = EdittedLeader.FirstName,
                    LastName = EdittedLeader.LastName,
                    DateOfBirth = EdittedLeader.DateOfBirth,
                    PhoneNo = EdittedLeader.PhoneNo,
                };
                var result = await teamLeaderRepo.UpdateLeader(edittedLeader, edittedLeader.Id);
                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamLeaders");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("EditLeaderForm", EdittedLeader);
                }

            }
            else
            {
                return View("EditLeaderForm", EdittedLeader);
            }
        }
        //Changing Password Form
        [Authorize(Roles = "Admin")]
        public IActionResult ChangePasswordForm(string LeaderID)
        {
            var leader = teamLeaderRepo.GetTeamLeader(LeaderID);
            var leaderNewPass = new ChangePasswordDTO()
            {
                UserID = leader.Id,
                FullName = leader.UserName,
                Email = leader.Email,
            };
            return View(leaderNewPass);
        }
        //Changing password fucntion
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangingPassword(ChangePasswordDTO newPasswordLeader)
        {
            if (ModelState.IsValid)
            {
                var result = await teamLeaderRepo.PasswordUpdate(newPasswordLeader.UserID, newPasswordLeader.OldPassword, newPasswordLeader.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamLeaders");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("ChangePasswordForm", newPasswordLeader);
                }
            }
            else
            {
                return View("ChangePasswordForm", newPasswordLeader);
            }
        }
        public async Task<IActionResult> DisableLeader(string memberID)
        {
            await teamLeaderRepo.DisableLeader(memberID);
            return RedirectToAction("AllTeamLeaders");
        }
        public async Task<IActionResult> EnableLeader(string memberID)
        {
            await teamLeaderRepo.EnableLeader(memberID);
            return RedirectToAction("AllTeamLeaders");
        }

    }
}
