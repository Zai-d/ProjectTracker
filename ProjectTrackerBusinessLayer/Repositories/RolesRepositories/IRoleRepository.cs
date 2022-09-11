using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.RolesRepositories
{
    public interface IRoleRepository
    {
        public List<IdentityRole> AllRoles();
    }
}
