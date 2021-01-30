using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModel
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public String Password { get; set; }
    }
}