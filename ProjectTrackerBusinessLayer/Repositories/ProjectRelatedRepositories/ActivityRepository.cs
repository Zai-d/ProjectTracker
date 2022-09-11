using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IProjectRepository projectRepo;
        private readonly ISprintRepository sprintRepo;
        private readonly IMissionRepository missionRepo;
        private readonly IWorkRepository workRepo;
        public ActivityRepository(ApplicationDbContext context, IProjectRepository projectRepo, ISprintRepository sprintRepo, IMissionRepository missionRepo, IWorkRepository workRepo)
        {
            this.context = context;
            this.projectRepo = projectRepo;
            this.sprintRepo = sprintRepo;
            this.missionRepo = missionRepo;
            this.workRepo = workRepo;
        }
        public void ProjectActivity(Project project)
        {
            var projectChange = new Activity()
            {
                DateTime = DateTime.Now,
                ProjectTitle = project.Name,
                ProjectDescription = project.Description,
                StatusID = project.StatusID
            };
            context.Activities.Add(projectChange);
            context.SaveChanges();
        }
        public void SprintActivity(Sprint sprint)
        {
            var sprintChange = new Activity()
            {
                DateTime = DateTime.Now,
                SprintName = sprint.Name,
                SprintStartDate = sprint.StartDate,
                SprintEndDate = sprint.EndDate,
                StatusID = sprint.StatusID
            };
            context.Activities.Add(sprintChange);
            context.SaveChanges();
        }

        public void MissionActivity(Mission mission)
        {
            var missionChange = new Activity()
            {
                DateTime = DateTime.Now,
                MissionTitle = mission.Name,
                MissionDescription = mission.MissionDescription,
                StatusID = mission.StatusID
            };
            context.Activities.Add(missionChange);
            context.SaveChanges();
        }
        public void WorkActivity(Work work)
        {
            List<string> attachments = new List<string>();

            if (work.Attachments != null)
            {
                foreach (var attach in work.Attachments)
                {
                    attachments.Add(attach.FileName);
                }

            }
            var Attachment = String.Join(",", attachments);
            var workChange = new Activity()
            {
                DateTime = DateTime.Now,
                WorkTitle = work.Name,
                WorkDescription = work.WorkDescription,
                StatusID = work.StatusID,
                TeamLeaderWorkNote = work.TeamLeaderNote,
                AttachmentName = Attachment
            };
            context.Activities.Add(workChange);
            context.SaveChanges();
        }
        public List<Activity> GetProjectActivities(string userID)
        {
            var projects = projectRepo.GetProjectForUser(userID);
            List<Activity> projectActivity = new List<Activity>();
            foreach (var project in projects)
            {
                projectActivity.AddRange(context.Activities.Include(x => x.Status).Where(x => x.ProjectTitle == project.Name));
            }
            return projectActivity;
        }
        public List<Activity> GetSprintActivities(string userID)
        {
            var projects = projectRepo.GetProjectForUser(userID);
            List<Activity> sprintActivity = new List<Activity>();
            foreach (var project in projects)
            {
                foreach (var sprint in project.Sprints)
                {
                    sprintActivity.AddRange(context.Activities.Include(x => x.Status).Where(x => x.SprintName == sprint.Name));

                }
            }
            return sprintActivity;
        }
        public List<Activity> GetMissionActivities(string userID)
        {
            var projects = projectRepo.GetProjectForUser(userID);
            List<Activity> missionActivity = new List<Activity>();

            foreach (var project in projects)
            {
                foreach (var sprint in project.Sprints)
                {
                    foreach (var mission in sprint.Missions)
                    {
                        missionActivity.AddRange(context.Activities.Include(x => x.Status).Where(x => x.MissionTitle == mission.Name));
                    }
                }
            }
            return missionActivity;
        }
        public List<Activity> GetWorkActivities(string userID)
        {
            var projects = projectRepo.GetProjectForUser(userID);
            List<Activity> workActivity = new List<Activity>();

            foreach (var project in projects)
            {
                foreach (var sprint in project.Sprints)
                {
                    foreach (var mission in sprint.Missions)
                    {
                        foreach (var work in mission.Works)
                        {
                            workActivity.AddRange(context.Activities.Include(x => x.Status).Where(x => x.WorkTitle == work.Name));

                        }
                    }
                }
            }

            return workActivity;
        }



    }
}
