﻿using System.ComponentModel.DataAnnotations;

namespace SocialMediaWeb.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string userName { get; set; }
        [Required] public string userEmail { get; set; }
        [Required]  public string  userPassword{ get; set; }

        [Required] [Compare("userPassword", ErrorMessage = "Password and Confirmation Password must match.")]public string confirmPassword { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
