﻿using System.ComponentModel.DataAnnotations;

namespace Fashion.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Email Address")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
