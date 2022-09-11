using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerApplicationLayer.DTO;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.RolesRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class UserController : Controller
    {
        //private readonly IRoleRepository roleRepository;
        private readonly IPositionRepository positionRepository;
        
        public UserController(/*IRoleRepository roleRepository, */IPositionRepository positionRepository)
        {
            //this.roleRepository = roleRepository;
            this.positionRepository = positionRepository;
           

        }
        [Authorize(Roles ="Admin")]
        public IActionResult NewEmployeeForm()
        {
            //ViewBag.Roles = roleRepository.AllRoles(); //still have to figure out if roles are needed, right now its useless
            //it is not needed
            var pos = positionRepository.AllPositions();
            pos.Remove(pos.SingleOrDefault(x => x.PositionID == 5));
            ViewBag.Positions = pos;
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddingNewEmployee(List<string> RoleIDs, int PositionID)
        {
            return PositionID switch
            {
                1 => RedirectToAction("NewTeamManagerForm", "TeamManager"),//can send the list of roles by using anon obj (new { RoleIDs= RoleIDs})
                2 => RedirectToAction("NewTeamLeaderForm", "TeamLeader"),
                3 => RedirectToAction("NewTeamMemberForm", "TeamMember", new { rank = PositionID }),
                4 => RedirectToAction("NewTeamMemberForm", "TeamMember", new { rank = PositionID }),
                _ => View(),
            };
        }
        
    }
}
