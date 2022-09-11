using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerApplicationLayer.DTO
{
	public class WorkAPI
	{
		public int workID { get; set; }
		public int missionID { get; set; }
		public string ProjectName { get; set; }
		[Required]
		public string WorkName { get; set; }
        [Required]
		public string memberID { get; set; }
		public string WorkDescription { get; set; }
		public string MemberName { get; set; }
		public string WorkStatus { get; set; }
		public int StatusID { get; set; }
		public string FilesNames { get; set; }
		public string TeamLeaderNote { get; set; }
		public IFormFile file { get; set; }
	}

}
