using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public DateTime DateTime { get; set; }
        public string WorkTitle { get; set; }
        public string WorkDescription { get; set; }
        public string AttachmentName { get; set; }  
        public string TeamLeaderWorkNote { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string SprintName { get; set; }
        [DataType(DataType.Date)]
        public DateTime SprintStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime SprintEndDate { get; set; }

        public int StatusID { get; set; }
        public Status Status { get; set; }




        //public Mission Mission { get; set; }
        //public int MissionID { get; set; }
        //public Work Work { get; set; }
        //public int WorkID { get; set; }
        //public Status Status { get; set; }
        //public int StatusID { get; set; }
    }
}

