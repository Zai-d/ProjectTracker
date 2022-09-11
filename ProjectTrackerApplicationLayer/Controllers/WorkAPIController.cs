using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System;
using System.Collections.Generic;

namespace ProjectTrackerApplicationLayer.Controllers
{
    public class WorkAPIController : Controller
    {
        private readonly IWorkRepository workRepo;
        private readonly IMissionRepository missionRepo;
        private readonly IAttachmentRepository attachmentRepo;
        private readonly IActivityRepository activityRepo;
        private readonly IStatusesRepository statusesRepo;
        public WorkAPIController(IWorkRepository workRepo, IMissionRepository missionRepo, IAttachmentRepository attachmentRepo, IActivityRepository activityRepo, IStatusesRepository statusesRepo)
        {
            this.workRepo = workRepo;
            this.missionRepo = missionRepo;
            this.attachmentRepo = attachmentRepo;
            this.activityRepo = activityRepo;
            this.statusesRepo = statusesRepo;   
        }


        //APIS
        //Getting all work
        [HttpGet]
        public JsonResult AllWorks(int missionID) // API example 
        {
            var works = workRepo.MissionsWorks(missionID);
            List<string> fileNames = new List<string>();
            List<WorkAPI> worksList = new List<WorkAPI>();
            foreach(var work in works)
            {

                var thiswork = new WorkAPI
                {
                    workID  = work.WorkID,
                    missionID = work.MissionID,
                    ProjectName = work.Mission.Sprint.Project.Name,
                    WorkName = work.Name,
                    WorkDescription = work.WorkDescription,
                    MemberName = work.Mission.TeamMember.UserName,
                    WorkStatus = work.Status.Name,
                    TeamLeaderNote = work.TeamLeaderNote ?? "no note"
                };
                fileNames.Clear();
                foreach (var file in work.Attachments)
                {
                    fileNames.Add(file.FileName);

                    
                }
                thiswork.FilesNames = String.Join(", ", fileNames);

                worksList.Add(thiswork);
            }
            return Json(worksList);
        }
        //All works table
        [HttpGet]
        public IActionResult AllWorksAPI(int missionID)
        {
            ViewBag.missionID = missionID;
            return View();
        }

        //Delete work function json
        [HttpDelete]
        public JsonResult DeleteWork(int workID)
        {
            
           workRepo.DeleteWork(workID);
          return Json(null);
        }

        //new work form
        public IActionResult NewWorkFormAPI(int missionID)
        {
            ViewBag.mission = missionRepo.GetMission(missionID);
            return View();
        }
        //Ajax add work
        [HttpPost]
        public JsonResult AddingWork(Work work, List<IFormFile> files, WorkAPI workAPI)
        {

            var workID = workRepo.AddWork(work);
            attachmentRepo.AddWorksAttachments(files, workID);
            activityRepo.WorkActivity(work);
            return Json(true);
        }

        //Edit work form
        public IActionResult EditWorkForm(int workID, int missionID)
        {
            var work = workRepo.GetWork(workID);
            ViewBag.mission = missionRepo.GetMission(missionID);
            ViewBag.Attachments = attachmentRepo.GetAttachments(workID);
            ViewBag.Statuses = statusesRepo.Statuses();
            return View(work);
        }
        [HttpPut]
        public JsonResult EdittingWork(List<int> AttachmentIDs, Work workEditted, List<IFormFile> files, string memberID)
        {
            attachmentRepo.DeleteAttachments(AttachmentIDs, workEditted.WorkID);
            workRepo.UpdateWork(workEditted);
            attachmentRepo.AddWorksAttachments(files, workEditted.WorkID);
            activityRepo.WorkActivity(workEditted);

            return Json(true);
        }



    }
}
