﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Compain_System.Shared
{
    class StudentRegisterViewModel
    {
        [Required]
        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Student Id")]
        public string StudentId { get; set; }


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
