using Microsoft.AspNetCore.Identity;
using SocialBets.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialBets.Services.Interfaces
{
   public interface IAccountService
    {
        Task<IdentityResult> Register(ApplicationUser user);
        Task<SignInResult> Login(ApplicationUser user, bool isRememberMeEnabled);
        Task Logout();
        Task<bool> isUserExists(ApplicationUser user);
        Task<bool> ResetPassword(ApplicationUser user);
    }
}
