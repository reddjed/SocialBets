using SocialBets.Domain.Interfaces.Database;
using SocialBets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialBets.Domain.Core.Models;
using System.Security.Claims;

namespace SocialBets.Infrastructure.BusinessLogic
{
    public class BattleService : IBattleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BattleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CurrentBattle>> GetBattles()
        {
            var battles = await _unitOfWork.CurrentBattleRepository.GetAll();

            return battles;
        }

        public async Task<CurrentBattle> GetBattle(Guid battleId)
        {
            return await _unitOfWork.CurrentBattleRepository.GetItem(battleId);
        }

        public async Task AttachToBattle(Guid battleId, ClaimsPrincipal claimsUser)
        {
            var battle = await _unitOfWork.CurrentBattleRepository.GetItem(battleId);
            var user = await _unitOfWork.UserManager.GetUserAsync(claimsUser);

            if (user is null)
                throw new NullReferenceException();

            if (battle.SecondPlayer is null)
                battle.SecondPlayer = user;

            _unitOfWork.CurrentBattleRepository.Update(battle);

            await _unitOfWork.SaveAsync();
        }

        public void CancelBattle(Guid battleId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateBattle(CurrentBattle battle)
        {
            if (battle is null)
                throw new ArgumentNullException();
            battle.Id = Guid.NewGuid();
            await _unitOfWork.CurrentBattleRepository.Add(battle);

            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> StartBattle(Guid battleId)
        {
            var battle = await _unitOfWork.CurrentBattleRepository.GetItem(battleId);

            if (battle.SecondPlayer is null)
                return false;

            battle.TimeOfStart = DateTime.Now;

            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> StopBattle(Guid battleId)
        {
            var battle = await _unitOfWork.CurrentBattleRepository.GetItem(battleId);

            if (battle.TimeOfStart < DateTime.Now)
                return false;
            if (battle.TimeOfEnd < DateTime.Now)
                return false;

            return true;
        }
    }
}
