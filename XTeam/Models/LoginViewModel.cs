using System.ComponentModel.DataAnnotations;

namespace XTeam.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("UserName", ErrorMessage = "UserName or Password Error !!")]
        public string Password { get; set; }
    }
}