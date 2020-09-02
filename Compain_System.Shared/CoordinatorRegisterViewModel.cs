using System;
using System.ComponentModel.DataAnnotations;

namespace Compain_System.Shared
{
    public class CoordinatorRegisterViewModel
    {
        [Required]
        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }


        [Required]
        [Display(Name = "Mobile number")]
        public string Mobile { get; set; }


        [Required]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("[\\w-]+@([\\w-]+\\.)+[\\w-]+", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d).{8,50}$", ErrorMessage = "Password must be between 8 and 50 digits long and include at least one numeric digit.")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
