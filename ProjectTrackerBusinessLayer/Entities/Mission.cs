using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Mission
    {
        public int MissionID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Mission Description")]
        public string MissionDescription { get; set; }

        public Sprint Sprint { get; set; }
        public int SprintID { get; set; }
        public List<Work> Works { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        public TeamMember TeamMember{ get; set; }
        public string TeamMemberID { get; set; }


    }
}
