using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Work
    {
        public int WorkID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string WorkDescription { get; set; }
        public string TeamLeaderNote { get; set; }

        public Mission Mission { get; set; }
        public int MissionID { get; set; }
        public Status Status { get; set; }
        public int StatusID { get; set; }
        public List<Attachment> Attachments { get; set; }



    }
}
