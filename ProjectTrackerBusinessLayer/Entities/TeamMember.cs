using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class TeamMember : User
    {
        public List<Mission> Missions { get; set; }
    }
}
