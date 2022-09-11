using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly ApplicationDbContext context;
        public MissionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Mission> SprintsMissions(int sprintID)
        {

            return context.Missions.Include(x => x.Status).Include(x => x.Sprint).ThenInclude(s => s.Project).Include(x => x.Works).Include(x => x.TeamMember).Where(x => x.SprintID == sprintID).ToList();
        }
        public void AddMission(Mission mission)
        {
            context.Missions.Add(mission);
            context.SaveChanges();
        }
        public Mission GetMission(int missionID)
        {
            return context.Missions.Include(x => x.Status).Include(x => x.Sprint).ThenInclude(s => s.Project).ThenInclude(p => p.UsersProjects).ThenInclude(up => up.User).Include(x => x.Works).Include(x => x.TeamMember).SingleOrDefault(x => x.MissionID == missionID);
        }
        public void UpdateMission(Mission mission)
        {
            context.Missions.Update(mission);
            context.SaveChanges();
        }
        public List<Mission> MembersMissions(int sprintID, string memberID)
        {


            var missionsInSprint = context.Missions.Include(x => x.Status).Include(x => x.Sprint).ThenInclude(s => s.Project).Include(x => x.Works).Include(x => x.TeamMember).Where(x => x.SprintID == sprintID).ToList();
            var membersMissions = missionsInSprint.Where(x => x.TeamMemberID == memberID).ToList();
            return membersMissions;
        }
        public bool MissionStatusChecker(int missionID)
        {
            var Mission = GetMission(missionID);
            return (Mission.StatusID != 4 && Mission.StatusID != 5 && Mission.Sprint.StatusID != 4 && Mission.Sprint.StatusID != 5 && Mission.Sprint.Project.StatusID != 4 && Mission.Sprint.Project.StatusID != 5) ? true : false;
        }

    }
}
