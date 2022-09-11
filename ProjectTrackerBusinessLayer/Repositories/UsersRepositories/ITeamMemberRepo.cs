using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public interface ITeamMemberRepository
    {
        public IdentityResult AddTeamMember(TeamMember teamMember, string Password, string RoleID, int PositionID);
        public List<TeamMember> AllTeamMembers();
        public TeamMember GetTeamMember(string TeamMemberID);
        public void DeleteTeamMember(TeamMember teamMember);
        public Task<IdentityResult> UpdateMember(TeamMember edittedMember, string memberID);
        public Task<IdentityResult> PasswordUpdate(string memberID, string oldPassword, string newPassword);
        public Task DisableMember(string memberID);
        public Task EnableMember(string memberID);

    }
}
