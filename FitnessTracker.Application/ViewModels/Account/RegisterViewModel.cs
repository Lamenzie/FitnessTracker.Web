using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Application.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Uživatelské jméno je povinné")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je povinný")]
        [EmailAddress(ErrorMessage = "Email není ve správném formátu")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Heslo je povinné")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Potvrzení hesla je povinné")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
