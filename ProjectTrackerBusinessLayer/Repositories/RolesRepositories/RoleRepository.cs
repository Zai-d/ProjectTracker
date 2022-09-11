using Microsoft.AspNetCore.Identity;
using ProjectTrackerBusinessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.RolesRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<IdentityRole> AllRoles()
        {
            return applicationDbContext.Roles.ToList();
        }
    }
}
