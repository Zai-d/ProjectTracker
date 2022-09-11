using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class ProjectController : Controller
    {
        private readonly ITeamLeaderRepository teamLeaderRepo;
        private readonly ITeamMemberRepository teamMemberRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IStatusesRepository statusesRepo;
        private readonly IActivityRepository activityRepo;
        public ProjectController(IProjectRepository projectRepo, ITeamLeaderRepository teamLeaderRepo, ITeamMemberRepository teamMemberRepo, IStatusesRepository statusesRepo, IActivityRepository activityRepo)
        {
            this.projectRepo = projectRepo;
            this.teamLeaderRepo = teamLeaderRepo;
            this.teamMemberRepo = teamMemberRepo;
            this.statusesRepo = statusesRepo;
            this.activityRepo = activityRepo;
        }
        //New Project Form
        [Authorize(Roles ="Team Manager,Admin")]
        public IActionResult CreateProject()
        {
            ViewBag.Leaders = teamLeaderRepo.GetAllTeamLeaders();
            ViewBag.Members = teamMemberRepo.AllTeamMembers();
            return View();

        }

        //Adding New Project toDataBase
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult AddingProject(ProjectDTO projectDTO)
        {
            if (ModelState.IsValid)
            {
                var project = new Project()
                {
                    Name = projectDTO.Name,
                    Description = projectDTO.Description,
                    DeadLine = projectDTO.DeadLine,
                    StatusID = 1,
                };
                int deadLine = project.DeadLine.CompareTo(DateTime.Now); //check
                if(deadLine < 1)
                {
                    ModelState.AddModelError(String.Empty, "Deadline can't be before today's date");
                    ViewBag.Leaders = teamLeaderRepo.GetAllTeamLeaders();
                    ViewBag.Members = teamMemberRepo.AllTeamMembers();
                    return View("CreateProject", projectDTO);
                }
                projectRepo.AddNewProject(project);
                var ManagerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                projectRepo.ProjectUsers(project.ProjectID, projectDTO.TeamMembersIDs, projectDTO.TeamLeaderID, ManagerID);
                activityRepo.ProjectActivity(project);
                return RedirectToAction("ManagerProjects", new { managerID = ManagerID });
            }
            else
            {
                ViewBag.Leaders = teamLeaderRepo.GetAllTeamLeaders();
                ViewBag.Members = teamMemberRepo.AllTeamMembers();
                return View("CreateProject", projectDTO);
            }
        }

        //All projects for logged Manager
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult ManagerProjects()
        {
            var managerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Projects = projectRepo.GetProjectForUser(managerID);
            return View(Projects);
        }

        //Edit Project form
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult EditProject(int ProjectID)
        {
            ViewBag.Leaders = teamLeaderRepo.GetAllTeamLeaders();
            ViewBag.Members = teamMemberRepo.AllTeamMembers();
            ViewBag.Statuses = statusesRepo.Statuses();
            return View(projectRepo.GetProject(ProjectID));
        }

        //Submitting editting to database
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult EdittingProject(ProjectDTO projectDTO)
        {
            if (ModelState.IsValid)
            {
                var project = new Project()
                {
                    ProjectID = projectDTO.ProjectID,
                    Name = projectDTO.Name,
                    Description = projectDTO.Description,
                    DeadLine = projectDTO.DeadLine,
                    StatusID = projectDTO.StatusID,
                };
                var ManagerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                projectRepo.EdittingProject(project, projectDTO.TeamMembersIDs, projectDTO.TeamLeaderID, ManagerID);
                activityRepo.ProjectActivity(project);
                return RedirectToAction("ManagerProjects", new { managerID = ManagerID });
            }
            else
            {
                ViewBag.Leaders = teamLeaderRepo.GetAllTeamLeaders();
                ViewBag.Members = teamMemberRepo.AllTeamMembers();
                return View(" EditProject", projectDTO);
            }

        }

        //List of projects assigned for logged TL
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult LeadersProjects()
        {
            var teamLeaderID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(projectRepo.GetProjectForUser(teamLeaderID));
        }

        //List of Projects assigned for logged member
        [Authorize(Roles ="Team Member,Admin")]
        public IActionResult MembersProjects()
        {
            var memberID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var projects = projectRepo.GetProjectForUser(memberID);
            return View(projects);
        }

    }
}
