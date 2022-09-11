using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerApplicationLayer.DTO
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }
            var val = (DateTime)value;

            if(val.AddYears(MinAge)> DateTime.Now)
            {
                return false;
            }
            else
            {
                return (val.AddYears(MaxAge)> DateTime.Now);
            }
        }
    }
}
