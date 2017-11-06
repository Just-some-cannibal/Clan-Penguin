using System.ComponentModel.DataAnnotations;

namespace ClanPenguin.ViewModels
{
    public class LoginViewModel : Main
    {
        [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name="Remember me")]
        public bool RememberMe { get; set; }
    }
}
