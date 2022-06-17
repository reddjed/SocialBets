using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialBets.Areas.Identity.Pages.Account;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Infrastructure.DataAccess;
using SocialBets.Models;
using SocialBets.Services.Interfaces;

namespace SocialBets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBattleService _battleService;


        public HomeController(ILogger<HomeController> logger, IBattleService battleService)
        {
            _logger = logger;
            _battleService = battleService;
        }
        
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("NonAuthorizedIndex");
            
            ICollection<CurrentBattle> battles = await _battleService.GetBattles();
            return View("Index", battles);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
