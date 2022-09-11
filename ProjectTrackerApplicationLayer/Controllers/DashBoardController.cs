using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using ProjectTrackerBusinessLayer.Repositories.UsersRepositories;
using System.Security.Claims;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly ITeamMemberRepository memberRepo;
        private readonly ITeamLeaderRepository leaderRepo;
        private readonly ITeamManagerRepository managerRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IWorkRepository workRepo;
        public DashBoardController(ITeamManagerRepository mangerRepo, ITeamLeaderRepository leaderRepo, ITeamMemberRepository memberRepo, IProjectRepository projectRepo, IWorkRepository workRepo)
        {
            this.managerRepo = mangerRepo;
            this.memberRepo = memberRepo;
            this.leaderRepo = leaderRepo;
            this.projectRepo = projectRepo;
            this.workRepo = workRepo;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashBoard()
        {

            ViewBag.ManagersCount = managerRepo.GetAllTeamManagers().Count;
            ViewBag.LeadersCount = leaderRepo.GetAllTeamLeaders().Count;
            var members = memberRepo.AllTeamMembers();
            int Juniors = 0, Seniors = 0;
            foreach (var member in members)
            {
                if (member.PositionID == 3)
                {
                    Seniors++;
                }
                else if (member.PositionID == 4)
                {
                    Juniors++;
                }
            }
            ViewBag.JuniorsCount = Juniors;
            ViewBag.SeniorsCount = Seniors;
            ViewBag.Projects = projectRepo.AllProjects();
            return View();
        }
        [Authorize(Roles = "Team Manager")]
        public IActionResult ManagerDashBoard()
        {
            ViewBag.LeadersCount = leaderRepo.GetAllTeamLeaders().Count;
            var members = memberRepo.AllTeamMembers();
            int Juniors = 0, Seniors = 0;
            foreach (var member in members)
            {
                if (member.PositionID == 3)
                {
                    Seniors++;
                }
                else if (member.PositionID == 4)
                {
                    Juniors++;
                }
            }
            ViewBag.JuniorsCount = Juniors;
            ViewBag.SeniorsCount = Seniors;
            ViewBag.Projects = projectRepo.GetProjectForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
        [Authorize(Roles = "Team Leader")]
        public IActionResult LeaderDashBoard()
        {
            ViewBag.Projects = projectRepo.GetProjectForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }
        [Authorize(Roles = "Team Member")]
        public IActionResult MemberDashBoard()
        {
            ViewBag.Projects = projectRepo.GetProjectForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            ViewBag.Works = workRepo.teamMemberWork(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View();
        }

    }
}
