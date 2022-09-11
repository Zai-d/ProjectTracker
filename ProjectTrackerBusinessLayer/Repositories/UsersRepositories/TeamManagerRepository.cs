using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public class TeamManagerRepository : ITeamManagerRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        public TeamManagerRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IdentityResult AddTeamManager(TeamManager teamManager, string Password, string RoleID, int PositionID)
        {
            var pass = userManager.CreateAsync(teamManager, Password).Result;
            teamManager.NormalizedUserName = teamManager.NormalizedEmail;
            if (pass.Succeeded)
            {
                context.UserRoles.Add(new IdentityUserRole<string>()
                {
                    RoleId = RoleID,
                    UserId = teamManager.Id
                });
                context.SaveChanges();

                return pass;
            }
            else
                return pass;
        }

        public List<TeamManager> GetAllTeamManagers()
        {

            return context.TeamManagers.Include(c => c.Position).Include(x => x.UsersProjects).ThenInclude(x => x.Project).ToList();
        }
        public TeamManager GetTeamManager(string ManagerID)
        {
            return context.TeamManagers.SingleOrDefault(x => x.Id == ManagerID);
        }

        public void DeleteTeamManager(TeamManager ManagerToDelete)
        {

            context.TeamManagers.Remove(ManagerToDelete);
            context.SaveChanges();
        }
        public async Task<IdentityResult> UpdateManager(TeamManager edittedManager, string managerID)
        {
            var user = await userManager.FindByIdAsync(managerID);
            if(user != null)
            {
                user.UserName = edittedManager.UserName;
                user.Email = edittedManager.Email;
                user.FirstName = edittedManager.FirstName;
                user.LastName = edittedManager.LastName;
                user.DateOfBirth = edittedManager.DateOfBirth;
                user.PhoneNo = edittedManager.PhoneNo;

                var result = await userManager.UpdateAsync(user);
                user.NormalizedUserName = edittedManager.Email;
                await context.SaveChangesAsync();
                return result;
            }
            return IdentityResult.Success;
        }
        public async Task<IdentityResult> PasswordUpdate(string managerID, string oldPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(managerID);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            user.NormalizedUserName = user.Email;
            context.SaveChanges();
            return result;
        }

        public async Task EnableManager(string managerID)
        {
            var manager = await userManager.FindByIdAsync(managerID);
            manager.EmailConfirmed = true;
            await context.SaveChangesAsync();
        }

        public async Task DisableManager(string managerID)
        {
            var manager = await userManager.FindByIdAsync(managerID);
            manager.EmailConfirmed = false;
            await context.SaveChangesAsync();
        }
    }
}
