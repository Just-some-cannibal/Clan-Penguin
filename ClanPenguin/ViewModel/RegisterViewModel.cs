using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClanPenguin.ViewModels
{
    public class RegisterViewModel : Main
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress, MaxLength(256), Display(Name ="Email Address"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmedPassword { get; set; }
    }
}
