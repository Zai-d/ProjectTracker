using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<User> userManager;
        public UserRepository(ApplicationDbContext applicationDbContext, UserManager<User> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        public List<User> AllUsers()
        {
            return applicationDbContext.Users.ToList();
        }

        public IdentityResult AddingAdmin(User Admin, string Password)
        {

            var pass = userManager.CreateAsync(Admin, Password).Result;
            Admin.NormalizedUserName = Admin.NormalizedEmail;
            if (pass.Succeeded)
            {
                applicationDbContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = Admin.Id
                });
                applicationDbContext.SaveChanges();
                return pass;

            }
            else
                return pass;

        }
    }
}
