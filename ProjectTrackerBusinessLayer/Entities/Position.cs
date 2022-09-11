using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Position 
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }

        public List<User> Users { get; set; }

    }
}
