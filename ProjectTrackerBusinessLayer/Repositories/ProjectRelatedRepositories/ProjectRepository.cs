using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;
using System.Linq.Expressions;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddNewProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
        //Add UsersProjects relation
        public void ProjectUsers(int projectID, List<string> membersIDs, string leaderID, string ManagerID)
        {

            foreach (var user in membersIDs)
            {
                _context.UsersProjects.Add(new UsersProjects
                {
                    ProjectID = projectID,
                    UserID = user
                });
                _context.SaveChanges();
            }
            _context.UsersProjects.Add(new UsersProjects
            {
                UserID = leaderID,
                ProjectID = projectID
            });
            _context.SaveChanges();
            _context.UsersProjects.Add(new UsersProjects
            {
                UserID = ManagerID,
                ProjectID = projectID
            });
            _context.SaveChanges();

        }
        //All projects for logged in manager
        public List<Project> GetProjectForUser(string userID)
        {

            var managerProjects = _context.UsersProjects.Where(x => x.UserID == userID).ToList();
            List<int> projectIDs = new List<int>();
            foreach (var Ids in managerProjects)
            {
                projectIDs.Add(Ids.ProjectID);
            }
            List<Project> projects = new List<Project>();
            foreach (var project in projectIDs)
            {
                
                projects.Add(_context.Projects.Include(x => x.Status).Include(x => x.Sprints).ThenInclude(x=>x.Missions).ThenInclude(x=>x.Works).Include(p => p.UsersProjects).ThenInclude(up => up.User).SingleOrDefault(x => x.ProjectID == project));
            }
         
            return projects;

        }
        //Gets the projected Needed to be Eddited
        public Project GetProject(int ProjectID)
        {
            return _context.Projects.Include(x => x.UsersProjects).ThenInclude(up => up.User).Include(x => x.Status).SingleOrDefault(x => x.ProjectID == ProjectID);
        }
        //Editting userprojects relation and the project's info
        public void EdittingProject(Project project, List<string> membersIDs, string leaderID, string ManagerID)
        {
            var userprojecets = _context.UsersProjects.Where(x => x.ProjectID == project.ProjectID);
            foreach (var userprojecet in userprojecets)
            {
                _context.UsersProjects.Remove(userprojecet);

            }
            _context.SaveChanges();
            List<string> members = new List<string>();
            members.Add(leaderID);
            members.Add(ManagerID);
            members.AddRange(membersIDs);
            foreach (string member in members)
            {
                _context.UsersProjects.Add(new UsersProjects()
                {
                    ProjectID = project.ProjectID,
                    UserID = member,
                });

            }
            _context.SaveChanges();
            _context.Projects.Update(project);
            _context.SaveChanges();



        }
        public List<Project> AllProjects()
        {
            return _context.Projects.Include(x => x.Sprints).ToList();
        }

    }
}
