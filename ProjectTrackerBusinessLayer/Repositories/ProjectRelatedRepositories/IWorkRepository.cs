using Microsoft.AspNetCore.Mvc;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IWorkRepository
    {
        public List<Work> MissionsWorks(int missionId);
        public List<Work> MembersWorks(int missionId, string memberID);
        public int AddWork(Work work);
        public Work GetWork(int workID);
        public void UpdateWork(Work work);
        public List<Work> teamMemberWork(string leaderID);

        //API
        //public List<Work> AllWorks();
        public void DeleteWork(int workID);
    }
}
