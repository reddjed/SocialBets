using Microsoft.AspNetCore.Identity;
using SocialBets.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialBets.Domain.Interfaces.Database
{
    public interface IUnitOfWork
    {
        public IRepository<BattleHistoryItem, int> BattleHistoryRepository { get; }
        public IRepository<CurrentBattle, Guid> CurrentBattleRepository { get; }
        public IRepository<MoneyAccount, int> MoneyAccountRepository { get; }
        public IRepository<OperationsHistoryItem, int> OperationsHistoryRepository { get; }
        public IRepository<OperationType, int> OperationTypeRepository { get; }
        public IRepository<SocialNetwork, int> SocialNetworkRepository { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public RoleManager<ApplicationRole> RoleManager { get;}
        Task SaveAsync();
    }
}
