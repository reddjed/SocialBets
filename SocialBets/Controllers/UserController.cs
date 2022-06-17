using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialBets.Areas.Identity.Pages.Account;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Services.Interfaces;

namespace SocialBets.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RegisterModel> _regLogger;
        private readonly ILogger<LoginModel> _loginLogger;

        public UserController(IAccountService accountService, IUnitOfWork unitOfWork, ILogger<RegisterModel> regLogger, ILogger<LoginModel> loginLogger)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
            _regLogger = regLogger;
            _loginLogger = loginLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginModel(_unitOfWork.SignInManager, _loginLogger).Input);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel.InputModel loginModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = loginModel.Email.Substring(0, loginModel.Email.IndexOf('@')),
                Email = loginModel.Email,
                Password = loginModel.Password
            };

            var loginResult = await _accountService.Login(user, loginModel.RememberMe);

            if (loginResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterModel(_unitOfWork.UserManager, _unitOfWork.SignInManager, _regLogger).Input);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel.InputModel registerModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = registerModel.Email.Substring(0, registerModel.Email.IndexOf('@')),
                Email = registerModel.Email,
                Password = registerModel.Password
            };

            var regResult = await _accountService.Register(user);

            if (regResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(registerModel);
        }
    }
}
