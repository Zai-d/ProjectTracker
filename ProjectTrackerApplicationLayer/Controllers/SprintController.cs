using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System;
using System.Linq;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class SprintController : Controller
    {
        private readonly ISprintRepository sprintRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IStatusesRepository statusesRepo;
        private readonly IActivityRepository activityRepo;
        public SprintController(ISprintRepository sprintRepo, IProjectRepository projectRepo, IStatusesRepository statusesRepo, IActivityRepository activityRepo)
        {
            this.sprintRepo = sprintRepo;
            this.projectRepo = projectRepo;
            this.statusesRepo = statusesRepo;
            this.activityRepo = activityRepo;
        }

        //Sprints View for the manager
        [Authorize(Roles ="Team Manager,Admin")]
        public IActionResult AllSprintsManager(int ProjectID)
        {
            var sprints = sprintRepo.GetProjectsSprints(ProjectID);
            ViewBag.Project = projectRepo.GetProject(ProjectID);
            return View(sprints);
        }

        //Sprints view for the TL
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult AllSprintsLeader(int ProjectID)
        {
            var sprints = sprintRepo.GetProjectsSprints(ProjectID);
            ViewBag.Project = projectRepo.GetProject(ProjectID);
            ViewBag.ProjectID = ProjectID;
            return View(sprints);
        }

        //Creating sprint form
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult CreateSprint(int ProjectID)
        {
            var project = projectRepo.GetProject(ProjectID);
            var sprint = new Sprint
            {
                Project = project
            };
            //ViewBag.Statuses = statusRepo.AllStatuses();
            return View(sprint);
        }

        //Adding sprint 
        [Authorize(Roles ="Team Leader,Admin")]//Not necessary
        public IActionResult AddingSprint(Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                var endDates = sprintRepo.SprintsEndDate(sprint.ProjectID);
                var lastSprintEndDate = endDates.LastOrDefault();
                int lastSprint = sprint.StartDate.CompareTo(lastSprintEndDate);
                int startDate = sprint.StartDate.CompareTo(sprint.Project.DeadLine);
                int endDate = sprint.EndDate.CompareTo(sprint.Project.DeadLine);
                int startendDate = sprint.EndDate.CompareTo(sprint.StartDate);
                while (startDate > -1 || endDate > -1 || startendDate < 1 || lastSprint < 1)
                {
                    if (startDate > -1)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage: "Please make sure the start date is before the Project's deadline");
                    }
                    if (endDate > -1)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage: "Please make sure the end date is before the Project's deadline");
                    }
                    if (startendDate < 1)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage: "Please make sure the end date is after the start date");
                    }
                    if (lastSprint < 1)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage: "Please make sure the start date is after all previous sprints ended");
                    }
                    return View(nameof(CreateSprint), sprint);
                }
                sprint.StatusID = 1;
                sprint.Project = null;
                sprintRepo.AddSprint(sprint);
                activityRepo.SprintActivity(sprint);
                return RedirectToAction("AllSprintsLeader", new { sprint.ProjectID });


            }
            else
            {
                return View(nameof(CreateSprint), sprint);
            }
        }

        //Edit Sprint Form
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult EditSprint(int sprintID)   
        {
            ViewBag.Statuses = statusesRepo.Statuses();
            return View(sprintRepo.GetSprint(sprintID));
        }

        //Editting Sprint in database
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult EdittingSprint(Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                var endDates = sprintRepo.SprintsEndDate(sprint.ProjectID);
                var lastSprintEndDate = endDates.LastOrDefault();
                int lastSprint = sprint.StartDate.CompareTo(lastSprintEndDate);
                int startDate = sprint.StartDate.CompareTo(sprint.Project.DeadLine);
                int endDate = sprint.EndDate.CompareTo(sprint.Project.DeadLine);
                int startendDate = sprint.EndDate.CompareTo(sprint.StartDate);
                while (startDate > -1 || endDate > -1 || startendDate < 1)
                {
                    if (startDate > -1)
                    {
                        ModelState.AddModelError(String.Empty, errorMessage: "Please make sure the start date is before the Project's deadline");
                    }
                    if (endDate > -1)
                    {
                        ModelState.AddModelError(String.Empty, errorMessage: "Please make sure the end date is before the Project's deadline");
                    }
                    if (startendDate < 1)
                    {
                        ModelState.AddModelError(String.Empty, errorMessage: "Please make sure the end date is after the start date");
                    }
                    if (lastSprint < 1)
                    {
                        ModelState.AddModelError(string.Empty, errorMessage: "Please make sure the start date is after all previous sprints ended");
                    }
                    return View(nameof(EditSprint), sprint);
                }
                sprint.Project = null;
                sprintRepo.UpdateSprint(sprint);
                activityRepo.SprintActivity(sprint); 
                return RedirectToAction(nameof(AllSprintsLeader), new { sprint.ProjectID });
            }
            else
            {
                return View(nameof(EditSprint), sprint);
            }
        }

        //All Sprints for logged member
        [Authorize(Roles ="Team Member,Admin")]
        public IActionResult AllSprintsMember(int projectID)
        {
            var sprints = sprintRepo.GetProjectsSprints(projectID);
            ViewBag.Project = sprints.FirstOrDefault(x => x.ProjectID == projectID).Project;
            ViewBag.memberID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(sprints);
        }
    }
}
