using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerApplicationLayer.DTO
{
    public class ChangePasswordDTO
    {
        public string UserID { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name ="Old Passowrd")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "New Passowrd")]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }
        [Display(Name = "Confirm New Passowrd")]
        [Required]
        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassord { get; set; }
    }
}
