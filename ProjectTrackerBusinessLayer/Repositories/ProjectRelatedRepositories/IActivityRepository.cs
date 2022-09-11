using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IActivityRepository
    {
        public void ProjectActivity(Project project);
        public void SprintActivity(Sprint sprint);
        public void MissionActivity(Mission mission);
        public void WorkActivity(Work work);
        public List<Activity> GetProjectActivities(string userID);
        public List<Activity> GetSprintActivities(string userID);
        public List<Activity> GetMissionActivities(string userID);
        public List<Activity> GetWorkActivities(string userID);

    }
}
