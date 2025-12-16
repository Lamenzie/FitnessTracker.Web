using FitnessTracker.Application.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Application.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResult> LoginAsync(LoginViewModel vm);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegisterViewModel vm, string roleName);
    }
}
