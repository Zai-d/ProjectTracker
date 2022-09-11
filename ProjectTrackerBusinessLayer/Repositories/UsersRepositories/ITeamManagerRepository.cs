using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public interface ITeamManagerRepository
    {

        public IdentityResult AddTeamManager(TeamManager teamManager, string Password, string RoleID, int PositionID);
        public List<TeamManager> GetAllTeamManagers();

        public TeamManager GetTeamManager(string ManagerID);
        public void DeleteTeamManager(TeamManager ManagerID);

        public Task<IdentityResult> UpdateManager(TeamManager edittedManager, string managerID);
        public Task<IdentityResult> PasswordUpdate(string managerID, string oldPassword, string newPassword);
        public Task EnableManager(string managerID);
        public Task DisableManager(string managerID);

    }
}
