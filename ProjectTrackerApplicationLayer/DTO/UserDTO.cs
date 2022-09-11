using ProjectTrackerBusinessLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerApplicationLayer.DTO
{
    public class UserDTO 
    {
        public string UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your number")]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [RegularExpression(pattern: @"^([0]{1}||([\+][9][6][2]){1})([7]{1})([789]{1})([0-9]{3})([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DateOfBirth(MinAge =18,MaxAge =50)]
        public DateTime? DateOfBirth { get; set; }
        
        public int PositionID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        
    }
}
