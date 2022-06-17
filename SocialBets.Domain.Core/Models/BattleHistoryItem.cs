using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using SocialBets.Domain.Core.Interfaces;

namespace SocialBets.Domain.Core.Models
{
    public class BattleHistoryItem : IEntity<int>, IBattle
    {
        
        public int Id { get; set; }
        public Guid BattleId { get; set; }
        public decimal Bet { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public DateTime TimeOfStart { get; set; }
        public DateTime TimeOfEnd { get; set; }
    }
}
