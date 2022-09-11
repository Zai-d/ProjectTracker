using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class WorkController : Controller
    {
        private readonly IWorkRepository workRepo;
        private readonly IMissionRepository missionRepo;
        private readonly IAttachmentRepository attachmentRepo;
        private readonly IStatusesRepository statusesRepo;
        private readonly IActivityRepository activityRepo;
        
        public WorkController(IWorkRepository workRepo, IMissionRepository missionRepo, IAttachmentRepository attachmentRepo, IStatusesRepository statusesRepo, IActivityRepository activityRepo)
        {
            this.workRepo = workRepo;
            this.missionRepo = missionRepo;
            this.attachmentRepo = attachmentRepo;
            this.statusesRepo = statusesRepo;
            this.activityRepo = activityRepo;
        }

        //team manager view for works
        [Authorize(Roles = "Team Manager,Admin")]
        public IActionResult AllWorksManager(int missionID)
        {
            var works = workRepo.MissionsWorks(missionID);
            ViewBag.mission = missionRepo.GetMission(missionID);
            return View(works);
        }

        //team leader view for works
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult AllWorksLeader(int missionID)
        {
            var works = workRepo.MissionsWorks(missionID);
            ViewBag.Mission = missionRepo.GetMission(missionID);

            return View(works);
        }

        //team member view for works
        [Authorize(Roles ="Team Member,Admin")]
        public IActionResult MembersWorks(int missionID)
        {
            
            string memberID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var works = workRepo.MembersWorks(missionID, memberID);
            ViewBag.Mission = missionRepo.GetMission(missionID);
            ViewBag.StatusesChecker = missionRepo.MissionStatusChecker(missionID); 
            ViewBag.missionID = missionID;

            return View(works);
        }

        //add work form
        [Authorize(Roles = "Team Member,Admin")]
        public IActionResult AddWork(int missionID)
        {
            ViewBag.mission = missionRepo.GetMission(missionID);
            return View();
        }

        //Adding work to database
        [Authorize(Roles = "Team Member,Admin")]
        [HttpPost]
        public IActionResult AddingWork(List<IFormFile> files, Work work, string memberID)
         {
            ModelState.Remove("Files");
            if (ModelState.IsValid)
            {
                work.StatusID = 1;

                var workID = workRepo.AddWork(work);

                attachmentRepo.AddWorksAttachments(files, workID);

                activityRepo.WorkActivity(work);
                return RedirectToAction("MembersWorks", new { work.MissionID, memberID });

            }
            else
            {
                ViewBag.mission = missionRepo.GetMission(work.MissionID);
                return View("AddWork",  work );
            }

        }

        //Edit work form
        [Authorize(Roles = "Team Member,Admin")]
        public IActionResult EditWork(int workID, int missionID)
        {
            var work = workRepo.GetWork(workID);
            ViewBag.mission = missionRepo.GetMission(missionID);
            ViewBag.Attachments = attachmentRepo.GetAttachments(workID);
            ViewBag.Statuses = statusesRepo.Statuses();
            return View(work);
        }

        //Editting work in database
        [Authorize(Roles = "Team Member,Admin")]
        public IActionResult EdittingWork(List<int> AttachmentIDs, Work workEditted, List<IFormFile> files, string memberID)
        {
            if (ModelState.IsValid)
            {
                attachmentRepo.DeleteAttachments(AttachmentIDs, workEditted.WorkID);
                workRepo.UpdateWork(workEditted);
                attachmentRepo.AddWorksAttachments(files, workEditted.WorkID);
                activityRepo.WorkActivity(workEditted);
                return RedirectToAction(nameof(MembersWorks), new { workEditted.MissionID, memberID });
            }
            else
            {
                ViewBag.Attachments = attachmentRepo.GetAttachments(workEditted.WorkID);
                ViewBag.Statuses = statusesRepo.Statuses();
                return View("EditWork", workEditted);
            }
        }

        //Team Leader's note on work
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult AddRejectNote(string note, int workID)
        {
            var work = workRepo.GetWork(workID);
            work.TeamLeaderNote = note;
            work.StatusID = 3;
            workRepo.UpdateWork(work);
            activityRepo.WorkActivity(work);
            return RedirectToAction("AllWorksLeader", new { work.MissionID });
        }

        //Team Leader approve work
        [Authorize(Roles ="Team Leader,Admin")]
        public IActionResult LeaderApprove(int workID)
        {
            var workApproved = workRepo.GetWork(workID);
            workApproved.StatusID = 2;
            workApproved.TeamLeaderNote = " ";
            workRepo.UpdateWork(workApproved);
            activityRepo.WorkActivity(workApproved);
            return RedirectToAction("AllWorksLeader", new { workApproved.MissionID });
        }
    }
}
