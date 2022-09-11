using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface ISprintRepository
    {
        public List<Sprint> GetProjectsSprints(int ProjectID);

        public void AddSprint(Sprint sprint);
        public Sprint GetSprint(int sprintID);
        public void UpdateSprint(Sprint sprint);
        public List<DateTime> SprintsEndDate(int ProjectID);
        public bool SprintStatusChecker(int sprintID);

    }
}
