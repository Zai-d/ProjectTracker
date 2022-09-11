using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Required(ErrorMessage ="Please enter the project's title")]
        [Display(Name = "Project Title")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the project's description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A deadline for the project is necessary")]
        public DateTime DeadLine { get; set; } = DateTime.Now;

    
        public List<Sprint> Sprints { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        public List<UsersProjects> UsersProjects { get; set; }


    }
}

