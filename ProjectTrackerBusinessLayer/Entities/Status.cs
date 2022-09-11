using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Status
    {
        public int StatusID { get; set; }
        public string Name { get; set; }

        public List<Work> Works { get; set; }
        public List<Mission> Missions { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<Project> Projects { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
