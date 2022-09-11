using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Sprint
    {
        public int SprintID { get; set; }
        public string Name { get; set; }
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(5).Date;

        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public List<Mission> Missions { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }


    }
}
