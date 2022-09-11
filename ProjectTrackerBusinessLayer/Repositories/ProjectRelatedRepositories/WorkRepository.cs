using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly ApplicationDbContext context;
        public WorkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Work> MissionsWorks(int missionId)
        {
            return context.Works.Include(x => x.Mission).ThenInclude(x => x.Sprint).ThenInclude(x=>x.Project).Include(x => x.Mission).ThenInclude(x => x.TeamMember).Include(x => x.Attachments).Include(x => x.Status).Where(x => x.MissionID == missionId).ToList();
        }

        public List<Work> MembersWorks(int missionId, string memberID)
        {

            var worksInMission = context.Works.Include(x => x.Attachments).Include(x => x.Mission).ThenInclude(x => x.Sprint).ThenInclude(x=>x.Project).Include(x => x.Status).Where(x => x.MissionID == missionId).ToList();

            return worksInMission;
        }
        public int AddWork(Work work)
        {
            context.Works.Add(work);
            context.SaveChanges();
            return work.WorkID;
        }
        public Work GetWork(int workID)
        {
            return context.Works.SingleOrDefault(x => x.WorkID == workID);
        }
        public void UpdateWork(Work work)
        {
            context.Works.Update(work);
            context.SaveChanges();
        }
        public List<Work> teamMemberWork(string memberID)
        {
            var missions = context.Missions.Include(x => x.Sprint).ThenInclude(x => x.Project).Where(x => x.TeamMemberID == memberID).ToList();
            List<int> missionsID = new List<int>();
            foreach (var mission in missions)
            {
                missionsID.Add(mission.MissionID);
            }
            List<Work> works = new List<Work>();
            foreach(var id in missionsID)
            {
                var missionsWork = context.Works.Include(x => x.Mission).ThenInclude(x => x.Sprint).ThenInclude(x => x.Project).Include(x=>x.Status).Where(x => x.MissionID==id).ToList().OrderBy(x=>x.Mission.Sprint.EndDate);
                works.AddRange(missionsWork);
            }
            return works;

        }
        //public List<Work> AllWorks()
        //{
        //    return context.Works.Include(x => x.Mission).ThenInclude(x => x.Sprint).ThenInclude(x => x.Project).Include(x => x.Status).Include(x => x.Mission).ThenInclude(x => x.TeamMember).Include(x => x.Attachments).ToList();
        //}
        public void DeleteWork(int workID)
        {
            //try
            //{
                //var workattachments = context.Attachments.Where(x => x.WorkID == workID);
                //foreach (var attach in workattachments)
                //{
                //    context.Attachments.Remove(attach);
                //}                
                context.Works.Remove(context.Works.SingleOrDefault(x => x.WorkID == workID));
                context.SaveChanges();
            //    return true;
            //}
            //catch(Exception e)
            //{
            //    return false;
            //}

        }

    }
}
