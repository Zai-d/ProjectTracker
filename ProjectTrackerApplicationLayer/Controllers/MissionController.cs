using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]
    public class MissionController : Controller
    {
        private readonly IMissionRepository missionRepo;
        private readonly ISprintRepository sprintRepo;
        private readonly IStatusesRepository statusesRepo;
        private readonly IActivityRepository activityRepo;
        public MissionController(IMissionRepository missionRepo, ISprintRepository sprintRepo, IStatusesRepository statusesRepo, IActivityRepository activityRepo)
        {
            this.missionRepo = missionRepo;
            this.sprintRepo = sprintRepo;
            this.statusesRepo = statusesRepo;
            this.activityRepo = activityRepo;
        }

        //All missions for specific project, Manager view
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult AllMissionsManager(int sprintID)
        {
            var missions = missionRepo.SprintsMissions(sprintID);
            ViewBag.Sprint = sprintRepo.GetSprint(sprintID);
            return View(missions);
        }

        //All missions for that sprint, TL View
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult AllMissionsLeader(int SprintID)
        {
            var missions = missionRepo.SprintsMissions(SprintID);
            ViewBag.StatusChecker = sprintRepo.SprintStatusChecker(SprintID);
            ViewBag.Sprint = sprintRepo.GetSprint(SprintID);

            ViewBag.SprintID = SprintID;
            return View(missions);
        }

        //create mission form
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult CreateMission(int sprintID)
        {
            var missionsSprint = sprintRepo.GetSprint(sprintID);
            var newMission = new Mission
            {
                Sprint = missionsSprint,
            };
            List<TeamMember> members = new List<TeamMember>();
            var usersInProject = missionsSprint.Project.UsersProjects;
            foreach (var member in usersInProject)
            {
                if (member.User.PositionID == 3 || member.User.PositionID == 4)
                {
                    members.Add((TeamMember)member.User);
                }
            }
            ViewBag.members = members;
            return View(newMission);
        }

        //adding mission for a specific  member
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult AddingMission(Mission mission)
        {
            if (ModelState.IsValid)
            {
                mission.StatusID = 1;
                missionRepo.AddMission(mission);

                activityRepo.MissionActivity(mission);
                return RedirectToAction(nameof(AllMissionsLeader), new { mission.SprintID });
            }
            else
            {
                var sprintID = mission.SprintID;
                var missionsSprint = sprintRepo.GetSprint(sprintID);
           
                List<TeamMember> members = new List<TeamMember>();
                var usersInProject = missionsSprint.Project.UsersProjects;
                foreach (var member in usersInProject)
                {
                    if (member.User.PositionID == 3 || member.User.PositionID == 4)
                    {
                        members.Add((TeamMember)member.User);
                    }
                }
                mission.Sprint = missionsSprint;
                ViewBag.members = members;
                return View("CreateMission", mission);
            }
        }

        //Edit mission form
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult EditMission(int missionID)
        {
            var mission = missionRepo.GetMission(missionID);
            List<TeamMember> members = new List<TeamMember>();
            var usersInProject = mission.Sprint.Project.UsersProjects;
            foreach (var member in usersInProject)
            {
                if (member.User.PositionID == 3 || member.User.PositionID == 4)
                {
                    members.Add((TeamMember)member.User);
                }
            }
            ViewBag.Statuses = statusesRepo.Statuses();
            ViewBag.members = members;
            return View(mission);
        }

        //Editting mission in database
        [Authorize(Roles = "Team Leader,Admin")]
        public IActionResult EdittingMission(Mission mission)
        {
            if (ModelState.IsValid)
            {
                missionRepo.UpdateMission(mission);
                activityRepo.MissionActivity(mission);
                return RedirectToAction(nameof(AllMissionsLeader), new { mission.SprintID });

            }
            else
            {
                return RedirectToAction("EditMission", new { mission.MissionID });
            }
        }

        //All missions for a sprint, Member View
        [Authorize(Roles ="Team Member,Admin")]
        public IActionResult MembersMissions(int sprintID)
        {
            var memberID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var missions = missionRepo.MembersMissions(sprintID, memberID);
            ViewBag.Sprint = missions.FirstOrDefault(x => x.SprintID == sprintID).Sprint;
            ViewBag.memberID = memberID;
            return View(missions);
        }

        //All worked finished and approved
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult AllWorkApproved(int MissionID)
        {
            var missionCompleted =missionRepo.GetMission(MissionID);
            missionCompleted.StatusID = 4;
            missionRepo.UpdateMission(missionCompleted);
            return RedirectToAction("AllMissionsLeader", new {sprintID = missionCompleted.SprintID});
        }

    }
}
