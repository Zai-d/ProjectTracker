using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IProjectRepository
    {
        public void AddNewProject(Project project);
        public void ProjectUsers(int projectID, List<string> membersIDs, string leaderID, string ManagerID);
        public List<Project> GetProjectForUser(string userID);

        public Project GetProject(int ProjectID);
        public List<Project> AllProjects();
        public void EdittingProject(Project project, List<string> membersIDs, string leaderID, string ManagerID);
    }
}
