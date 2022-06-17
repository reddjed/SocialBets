using System;
using System.Collections.Generic;
using System.Text;

using SocialBets.Domain.Core.Interfaces;

namespace SocialBets.Domain.Core.Models
{
    public class CurrentBattle : IEntity<Guid>, IBattle
    {

        public Guid Id { get; set; }
        public ApplicationUser FirstPlayer { get; set; }
        public ApplicationUser SecondPlayer { get; set; } = null;
        public DateTime TimeOfEnd { get; set; }
        public DateTime TimeOfStart { get; set; }
        public string FirstPlayerUrl { get; set; }
        public string SecondPlayerUrl { get; set; } = null;
        public decimal Bet { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        
    }
}
