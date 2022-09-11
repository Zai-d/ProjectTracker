using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public TeamMemberRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IdentityResult AddTeamMember(TeamMember teamMember, string Password, string RoleID, int PositionID)
        {
            var pass = userManager.CreateAsync(teamMember, Password).Result;
            teamMember.NormalizedUserName = teamMember.NormalizedEmail;
            if (pass.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = RoleID,
                    UserId = teamMember.Id
                });
                context.SaveChanges();
                return pass;
            }
            return pass;
        }
        public List<TeamMember> AllTeamMembers()
        {
            return context.TeamMember.Include(x => x.Position).Include(pr => pr.UsersProjects).ThenInclude(p => p.Project).ToList();
        }
        public TeamMember GetTeamMember(string TeamMemberID)
        {
            return context.TeamMember.SingleOrDefault(x => x.Id == TeamMemberID);
        }
        public void DeleteTeamMember(TeamMember teamMember)
        {
            context.TeamMember.Remove(teamMember);
            context.SaveChanges();
        }
        public async Task<IdentityResult> UpdateMember(TeamMember edittedMember, string memberID)
        {
            var user = await userManager.FindByIdAsync(memberID);
            if (user != null)
            {
                user.UserName = edittedMember.UserName;
                user.Email = edittedMember.Email;
                user.FirstName = edittedMember.FirstName;
                user.LastName = edittedMember.LastName;
                user.DateOfBirth = edittedMember.DateOfBirth;
                user.PhoneNo = edittedMember.PhoneNo;

                var result = await userManager.UpdateAsync(user);
                user.NormalizedUserName = edittedMember.Email;
                await context.SaveChangesAsync();
                return result;
            }
            return IdentityResult.Success;
        }
        public async Task<IdentityResult> PasswordUpdate(string memberID, string oldPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(memberID);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            user.NormalizedUserName = user.Email;
            context.SaveChanges();
            return result;

        }
        public async Task DisableMember(string memberID)
        {
            var member = await userManager.FindByIdAsync(memberID);
            member.EmailConfirmed=false;
            await context.SaveChangesAsync();
        }
        public async Task EnableMember(string memberID)
        {
            var member = await userManager.FindByIdAsync(memberID);
            member.EmailConfirmed = true;
            await context.SaveChangesAsync();
        }

    }
}
