using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="This field is required.")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage ="Enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public String SetPassword(string newPassword)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            Password = passwordHasher.HashPassword(newPassword);
            return Password;
        }

        public PasswordVerificationResult VerifyPassword(string passwordCandidate)
        {
            PasswordHasher passwordHasher = new PasswordHasher();            
            return passwordHasher.VerifyHashedPassword(Password, passwordCandidate);
        }

        [Required(ErrorMessage = "This field is required.")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}