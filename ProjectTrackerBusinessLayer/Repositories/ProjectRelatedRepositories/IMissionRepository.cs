using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IMissionRepository
    {
        public List<Mission> SprintsMissions(int sprintID);
        public void AddMission(Mission mission);
        public Mission GetMission(int missionID);
        public void UpdateMission(Mission mission);
        public List<Mission> MembersMissions(int sprintID, string memberID);
        public bool MissionStatusChecker(int missionID);
    }
}
