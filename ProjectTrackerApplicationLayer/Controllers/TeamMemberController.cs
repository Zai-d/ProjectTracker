using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberRepository teamMemberRepo;
        private readonly ApplicationDbContext context;//for api test
    
        public TeamMemberController(ApplicationDbContext context, ITeamMemberRepository teamMemberRepo)

        {
            this.context = context;
            this.teamMemberRepo = teamMemberRepo;
        }
        //public IActionResult MembersProjects(string memberID)
        //{
        //    var projects = projectRepo.GetProjectForUser(memberID);
        //    return View(projects);
        //}
        //public IActionResult AllSprints(int projectID)
        //{
        //    var sprints  = sprintRepo.GetProjectsSprints(projectID);
        //    ViewBag.Project = sprints.FirstOrDefault(x=>x.ProjectID==projectID).Project;
        //    ViewBag.memberID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return View(sprints);
        //}
        //public IActionResult MembersMissions(int sprintID, string memberID)
        //{
        //    var missions = missionRepo.MembersMissions(sprintID, memberID);
        //    ViewBag.Sprint = missions.FirstOrDefault(x => x.SprintID == sprintID).Sprint;
        //    ViewBag.memberID = memberID;
        //    return View(missions);
        //}
        //public IActionResult MembersWorks(int missionID, string memberID)
        //{
        //    var works = workRepo.MembersWorks(missionID, memberID);
        //    if (works.Any())
        //    {
        //        ViewBag.Mission = works.FirstOrDefault(x => x.MissionID == missionID).Mission;
        //    }
        //    ViewBag.missionID = missionID;
        //    return View(works);
        //}
        //public IActionResult AddWork(int missionID)
        //{
        //    ViewBag.mission = missionRepo.GetMission(missionID);
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddingWork(List<IFormFile> files, Work work, string memberID) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        work.StatusID = 1;

        //        var workID = workRepo.AddWork(work);

        //        attachmentRepo.AddWorksAttachments(files, workID);

        //        return RedirectToAction("MembersWorks", new { work.MissionID, memberID });

        //    }
        //    else
        //    {
        //        return View("AddWork", new { files, work });
        //    }

        //}
        //public FileResult OpenFile(int attachmentID)
        //{
        //    var file =attachmentRepo.GetAttachment(attachmentID);
        //    Stream fileStream = new MemoryStream(file.FileData);
        //    return new FileStreamResult(fileStream, file.FileType);
        //}
        //public IActionResult EditWork(int workID, int missionID)
        //{

        //    var work = workRepo.GetWork(workID);
        //    ViewBag.mission = missionRepo.GetMission(missionID);
        //    ViewBag.Attachments =  attachmentRepo.GetAttachments(workID);
        //    ViewBag.Statuses = statusRepo.AllStatuses();
        //    return View(work);
        //}
        //public IActionResult EdittingWork(List<int> AttachmentIDs, Work workEditted, List<IFormFile> files, string memberID)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        attachmentRepo.DeleteAttachments(AttachmentIDs, workEditted.WorkID);
        //        workRepo.UpdateWork(workEditted);
        //        attachmentRepo.AddWorksAttachments(files, workEditted.WorkID);

        //        return RedirectToAction(nameof(MembersWorks), new { workEditted.MissionID, memberID});
        //    }
        //    else
        //    {
        //        ViewBag.Attachments = attachmentRepo.GetAttachments(workEditted.WorkID);
        //        ViewBag.Statuses = statusRepo.AllStatuses();
        //        return View("EditWork", workEditted);
        //    }
        //}
        //testing APIs
        
        [Authorize(Roles ="Admin")]
        public IActionResult NewTeamMemberForm(int rank)//New Team Member Form
        {
            ViewBag.rank = rank;
            return View();
        }

        //Adding new team member to database
        [Authorize(Roles = "Admin")]
        public IActionResult AddingTeamMember(UserDTO Member, int rank)
        {
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", Member.FirstName, Member.LastName);
                var teamMember = new TeamMember()
                {
                    UserName = fullName,
                    Email = Member.Email,
                    FirstName = Member.FirstName,
                    LastName = Member.LastName,
                    DateOfBirth = Member.DateOfBirth,
                    PhoneNo = Member.PhoneNo,
                    PositionID = rank,
                    EmailConfirmed = true,
                };
                var pass = teamMemberRepo.AddTeamMember(teamMember, Member.Password, "4", rank);
                if (!pass.Succeeded)
                {
                    foreach (var Error in pass.Errors)
                    {
                        ModelState.AddModelError(string.Empty, Error.Description);
                    }
                    return View("NewTeamMemberForm", Member);
                }
                else
                {
                    return RedirectToAction("AllTeamMembers");
                }
            }
            else
            {
                return View("NewTeamMemberForm", Member);
            }

        }

        //Full List view
        [Authorize(Roles = "Admin")]
        public IActionResult AllTeamMembers()
        {
            var teamMembers = teamMemberRepo.AllTeamMembers();
            return View(teamMembers);
        }

        //deleting function
        //[Authorize(Roles = "Admin")]
        //[HttpDelete]
        //public IActionResult DeleteMember(string MemberID)
        //{
        //    teamMemberRepo.DeleteTeamMember(teamMemberRepo.GetTeamMember(MemberID));
        //    return RedirectToAction("AllTeamMembers");
        //}

        //Edit leader form

        [Authorize(Roles = "Admin")]
        public IActionResult EditMemberForm(string MemberID)
        {
            var teamMember = teamMemberRepo.GetTeamMember(MemberID);

            var teamMemberToEdit = new UserDTO()
            {
                UserID = MemberID,
                Email = teamMember.Email,
                DateOfBirth = teamMember.DateOfBirth,
                FirstName = teamMember.FirstName,
                LastName = teamMember.LastName,
                PhoneNo = teamMember.PhoneNo,
                PositionID = teamMember.PositionID
            };

            return View(teamMemberToEdit);
        }

        //Edit leader function
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EdittingTeamMember(UserDTO EdittedMember)
        {
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var fullName = String.Join(" ", EdittedMember.FirstName, EdittedMember.LastName);
                var edittedMember = new TeamMember()
                {
                    Id = EdittedMember.UserID,
                    UserName = fullName,
                    Email = EdittedMember.Email,
                    FirstName = EdittedMember.FirstName,
                    LastName = EdittedMember.LastName,
                    DateOfBirth = EdittedMember.DateOfBirth,
                    PhoneNo = EdittedMember.PhoneNo,
                };
                var result = await teamMemberRepo.UpdateMember(edittedMember, edittedMember.Id);
                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamMembers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("EditMemberForm", EdittedMember);
                }

            }
            else
            {
                return View("EditMemberForm", EdittedMember);
            }
        }
        //Changing Password Form
        [Authorize(Roles = "Admin")]
        public IActionResult ChangePasswordForm(string MemberID)
        {
            var member = teamMemberRepo.GetTeamMember(MemberID);
            var memberNewPass = new ChangePasswordDTO()
            {
                UserID = member.Id,
                FullName = member.UserName,
                Email = member.Email,
            };
            return View(memberNewPass);
        }
        //Changing password fucntion
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangingPassword(ChangePasswordDTO newPasswordMember)
        {
            if (ModelState.IsValid)
            {
                var result = await teamMemberRepo.PasswordUpdate(newPasswordMember.UserID, newPasswordMember.OldPassword, newPasswordMember.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllTeamMembers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                    return View("ChangePasswordForm", newPasswordMember);
                }
            }
            else
            {
                return View("ChangePasswordForm", newPasswordMember);
            }
        }
        public async Task<IActionResult> DisableMember(string memberID)
        {
            await teamMemberRepo.DisableMember(memberID);
            return RedirectToAction("AllTeamMembers");
        }
        public async Task<IActionResult> EnableMember(string memberID)
        {
            await teamMemberRepo.EnableMember(memberID);
            return RedirectToAction("AllTeamMembers");
        }

    }
}
