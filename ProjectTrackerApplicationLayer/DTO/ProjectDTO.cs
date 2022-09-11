using ProjectTrackerBusinessLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerApplicationLayer.DTO
{
    public class ProjectDTO : Project
    {
        [Required]
        [Display(Name="Team Leader")]
        public string TeamLeaderID { get; set; }
        [Required]
        [Display(Name = "Team Members")]
        public List<string> TeamMembersIDs { get; set; }
    }

}
