using System.Web;
using Microsoft.AspNetCore.Identity;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SocialBets.Infrastructure.BusinessLogic
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResult> Login(ApplicationUser user, bool isRememberMeEnabled)
        {
            return await _unitOfWork.SignInManager.PasswordSignInAsync(user.UserName, user.Password, isRememberMeEnabled, false);
        }

        public async Task Logout()
        {
            await _unitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(ApplicationUser user)
        {
            if(await isUserExists(user))
                return IdentityResult.Failed();

            user.PasswordHash = _unitOfWork.UserManager.PasswordHasher.HashPassword(user, user.Password);

            var result = await _unitOfWork.UserManager.CreateAsync(user);

            if(result.Succeeded)
            {
               await _unitOfWork.SignInManager.SignInAsync(user, false);
            }

            return result;
        }

        public Task<bool> ResetPassword(ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> isUserExists(ApplicationUser user)
        {
            var result = await _unitOfWork.UserManager.FindByEmailAsync(user.Email)
                ?? (user.UserName != null ? await _unitOfWork.UserManager.FindByNameAsync(user.UserName) : null);
            return result != null;
        }
    }
}
