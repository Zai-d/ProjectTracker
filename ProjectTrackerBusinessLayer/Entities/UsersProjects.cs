using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class UsersProjects
    {
        public User User { get; set; }
        public string UserID { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
    }
}
