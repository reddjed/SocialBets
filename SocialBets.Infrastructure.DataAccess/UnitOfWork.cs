using Microsoft.AspNetCore.Identity;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using SocialBets.Infrastructure.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace SocialBets.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork        //https://medium.com/@chathuranga94/unit-of-work-for-asp-net-core-706e71abc9d1
    {
        private readonly ApplicationDbContext _ctx;

        public IRepository<BattleHistoryItem, int> BattleHistoryRepository { get; }
        public IRepository<CurrentBattle, Guid> CurrentBattleRepository { get; }
        public IRepository<MoneyAccount, int> MoneyAccountRepository { get; }
        public IRepository<OperationsHistoryItem, int> OperationsHistoryRepository { get; }
        public IRepository<OperationType, int> OperationTypeRepository { get; }
        public IRepository<SocialNetwork, int> SocialNetworkRepository { get; }
        public IRepository<Statistics, int> StatisticsRepository { get; }
        public IRepository<UserInfo, int> UserInfoRepository { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public RoleManager<ApplicationRole> RoleManager { get; }


        public UnitOfWork(ApplicationDbContext ctx, UserManager<ApplicationUser> UserManager, RoleManager<ApplicationRole> RoleManager, SignInManager<ApplicationUser> SignInManager)
        {
            _ctx = ctx;

            BattleHistoryRepository = new DbRepository<BattleHistoryItem, int>(_ctx);
            CurrentBattleRepository = new DbRepository<CurrentBattle, Guid>(_ctx);
            MoneyAccountRepository = new DbRepository<MoneyAccount, int>(_ctx);
            OperationsHistoryRepository = new DbRepository<OperationsHistoryItem, int>(_ctx);
            OperationTypeRepository = new DbRepository<OperationType, int>(_ctx);
            SocialNetworkRepository = new DbRepository<SocialNetwork, int>(_ctx);
            StatisticsRepository = new DbRepository<Statistics, int>(_ctx);
            UserInfoRepository = new DbRepository<UserInfo, int>(_ctx);
            this.UserManager = UserManager;
            this.RoleManager = RoleManager;
            this.SignInManager = SignInManager;
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }

    }
}
