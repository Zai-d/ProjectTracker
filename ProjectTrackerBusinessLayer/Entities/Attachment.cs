using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTrackerBusinessLayer.Entities
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Byte[] FileData { get; set; }

        public Work Work { get; set; }
        public int WorkID { get; set; }
    }
}
