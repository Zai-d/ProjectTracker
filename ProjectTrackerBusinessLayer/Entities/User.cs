using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ProjectTrackerBusinessLayer.Entities
{
    public class User : IdentityUser
    {
        //requirments and validation is not necessary here
   
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your number")]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [RegularExpression(pattern: @"^([0]{1}||([\+][9][6][2]){1})([7]{1})([789]{1})([0-9]{3})([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public Position Position { get; set; }
        public int PositionID { get; set; }
        public List<UsersProjects> UsersProjects { get; set; }


    }

}
