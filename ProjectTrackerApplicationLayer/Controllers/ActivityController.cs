using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System.Data;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize(Roles= "Admin,Team Manager")]
    public class ActivityController : Controller
    {
        private readonly IActivityRepository activityRepo;
        public ActivityController(IActivityRepository activityRepo)
        {
            this.activityRepo = activityRepo;
        }

        public IActionResult ProjectActivities()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var projectActivities =activityRepo.GetProjectActivities(userID);
            return View(projectActivities);
        }
        public IActionResult SprintActivities()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sprintActivities = activityRepo.GetSprintActivities(userID);
            return View(sprintActivities);
        }
        public IActionResult MissionActivities()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var missionActivities = activityRepo.GetMissionActivities(userID);
            return View(missionActivities);
        }
        public IActionResult WorkActivities()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var workActivities = activityRepo.GetWorkActivities(userID);
            return View(workActivities);
        }
    }
}
