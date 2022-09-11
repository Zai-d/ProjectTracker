using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public class TeamLeaderRepository : ITeamLeaderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public TeamLeaderRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IdentityResult AddTeamLeader(TeamLeader teamLeader, string Password, string RoleID, int PositionID)
        {
            var pass = userManager.CreateAsync(teamLeader, Password).Result;
            teamLeader.NormalizedUserName = teamLeader.NormalizedEmail;
            if (pass.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>()
                {
                    RoleId = RoleID,
                    UserId = teamLeader.Id
                });
                context.SaveChanges();
                return pass;
            }
            else
            {
                return pass;
            }

        }

        public void DeleteTeamLeader(TeamLeader teamLeader)
        {
            try
            {
                context.TeamLeaders.Remove(teamLeader);
                context.SaveChanges();
            }
            catch (Exception e)
            {
              
                    MessageBox.Show("You can't delete a user that has projects");
         
            }
        }

        public List<TeamLeader> GetAllTeamLeaders()
        {
            return context.TeamLeaders.Include(p => p.Position).Include(up => up.UsersProjects).ThenInclude(pr => pr.Project).ToList();
        }

        public TeamLeader GetTeamLeader(string TeamLeaderID)
        {
            return context.TeamLeaders.SingleOrDefault(x => x.Id == TeamLeaderID);
        }
        public async Task<IdentityResult> UpdateLeader(TeamLeader edittedLeader, string leaderID)
        {
            var user = await userManager.FindByIdAsync(leaderID);
            if (user != null)
            {
                user.UserName = edittedLeader.UserName;
                user.Email = edittedLeader.Email;
                user.FirstName = edittedLeader.FirstName;
                user.LastName = edittedLeader.LastName;
                user.DateOfBirth = edittedLeader.DateOfBirth;
                user.PhoneNo = edittedLeader.PhoneNo;

                var result = await userManager.UpdateAsync(user);
                user.NormalizedUserName = edittedLeader.Email;
                await context.SaveChangesAsync();
                return result;
            }
            return IdentityResult.Success;
        }
        public async Task<IdentityResult> PasswordUpdate(string leaderID, string oldPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(leaderID);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            user.NormalizedUserName = user.Email;
            context.SaveChanges();
            return result;
        }
        public async Task DisableLeader(string leaderID)
        {
            var leader = await userManager.FindByIdAsync(leaderID);
            leader.EmailConfirmed = false;
            await context.SaveChangesAsync();
        }
        public async Task EnableLeader(string leaderID)
        {
            var leader = await userManager.FindByIdAsync(leaderID);
            leader.EmailConfirmed = true;
            await context.SaveChangesAsync();
        }


    }
}
