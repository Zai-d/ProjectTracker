using System;
using ProjectTrackerBusinessLayer.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectTrackerBusinessLayer.Repositories.UsersRepositories
{
    public interface IUserRepository
    {
        public IdentityResult AddingAdmin(User Admin, string Password);
        public List<User> AllUsers();

    }
}
