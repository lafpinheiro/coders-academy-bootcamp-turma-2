using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

    }
    
}