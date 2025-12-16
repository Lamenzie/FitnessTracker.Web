using FitnessTracker.Application.Interfaces;
using FitnessTracker.Application.ViewModels.Account;
using FitnessTracker.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Infrastructure.Services
{
    public class AccountIdentityService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountIdentityService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel vm)
        {
            return await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel vm, string roleName)
        {
            var user = new AppUser
            {
                UserName = vm.UserName,
                Email = vm.Email
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded) return result;

            // Přidání role (defaultně User)
            await _userManager.AddToRoleAsync(user, roleName);
            return result;
        }
    }
}
