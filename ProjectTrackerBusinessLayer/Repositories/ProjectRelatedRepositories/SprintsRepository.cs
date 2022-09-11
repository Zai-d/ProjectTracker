using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class SprintRepository : ISprintRepository
    {
        private readonly ApplicationDbContext context;
        public SprintRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Sprint> GetProjectsSprints(int ProjectID)
        {

            return context.Sprints.Include(x => x.Project).ThenInclude(p => p.UsersProjects).ThenInclude(up => up.User).Include(x => x.Missions).Include(x => x.Status).Where(x => x.ProjectID == ProjectID).ToList();
        }
        public void AddSprint(Sprint sprint)
        {
            int projectID = sprint.ProjectID;
            context.Sprints.Add(sprint);
            //sprint.ProjectID = projectID;
            context.SaveChanges();

        }
        public Sprint GetSprint(int sprintID)
        {
            //added two then include because of uses in create missions
            return context.Sprints.Include(x => x.Project).ThenInclude(p => p.UsersProjects).ThenInclude(up => up.User).SingleOrDefault(x => x.SprintID == sprintID);
        }
        public void UpdateSprint(Sprint sprint)
        {
            context.Sprints.Update(sprint);
            context.SaveChanges();
        }
        public List<DateTime> SprintsEndDate(int ProjectID)
        {
            var dateTime = from u in context.Sprints
                           where u.ProjectID == ProjectID
                           orderby u.EndDate
                           select u.EndDate;
            return dateTime.ToList();
        }
        public bool SprintStatusChecker(int sprintID)
        {
            var Sprint= GetSprint(sprintID);

            return (Sprint.StatusID != 4 && Sprint.StatusID != 5 && Sprint.Project.StatusID != 4 && Sprint.Project.StatusID != 5) ? true : false;

        }
    }
}
