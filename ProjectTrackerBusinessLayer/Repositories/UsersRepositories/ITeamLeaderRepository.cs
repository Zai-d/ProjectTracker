using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public interface ITeamLeaderRepository
    {
        public IdentityResult AddTeamLeader(TeamLeader teamLeader, string Password, string RoleID, int PositionID);
        public List<TeamLeader> GetAllTeamLeaders();

        public TeamLeader GetTeamLeader(string TeamLeaderID);
        public void DeleteTeamLeader(TeamLeader teamLeader);
        public Task<IdentityResult> UpdateLeader(TeamLeader edittedLeader, string leaderID);
        public Task<IdentityResult> PasswordUpdate(string leaderID, string oldPassword, string newPassword);
        public Task DisableLeader(string leaderID);
        public Task EnableLeader(string leaderID);


    }
}
