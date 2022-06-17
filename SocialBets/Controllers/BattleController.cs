using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Services.Interfaces;

namespace SocialBets.Controllers
{
   // [Authorize]
    public class BattleController : Controller
    {
        private readonly IBattleService _battleService;
        private readonly ILogger<BattleController> _logger;
        public BattleController(IBattleService battleService, ILogger<BattleController> logger)
        {
            _battleService = battleService;
            _logger = logger;
        }

        // GET: Battle
        public IActionResult Add()
        {
            return View("../../Views/Home/BattleView");

        }

        [HttpPost]
        public async Task<IActionResult> Add(CurrentBattle battle)
        {
            try
            {
                await _battleService.CreateBattle(battle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        //POST: Attach to battle
        [HttpPost]
        public async Task<IActionResult> Attach(Guid battleId)
        {
            try
            {
                await _battleService.AttachToBattle(battleId, User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return RedirectToAction("BattleStart", battleId);
        }

        public async Task<IActionResult> BattleStart(Guid battleId)
        {
            var status = await _battleService.StartBattle(battleId);

            if (!status)
                return StatusCode(400);

            return RedirectToAction("Index", "HomeController");
        }

        public async Task<IActionResult> BattleStop(Guid battleId)
        {
            var status = await _battleService.StartBattle(battleId);

            if (!status)
                return StatusCode(400);

            return RedirectToAction("Index", "HomeController");
        }


    }
}