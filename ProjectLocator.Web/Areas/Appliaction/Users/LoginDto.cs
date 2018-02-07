﻿using System.ComponentModel.DataAnnotations;

namespace ProjectLocator.Web.Areas.Appliaction.Users
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}