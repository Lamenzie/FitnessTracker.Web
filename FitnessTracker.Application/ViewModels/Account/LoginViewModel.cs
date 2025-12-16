using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Application.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Uživatelské jméno je povinné")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Heslo je povinné")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
