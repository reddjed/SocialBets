using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace SocialBets.Domain.Core.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string ImagePath { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public MoneyAccount MoneyAccount { get; set; }
        public UserInfo UserInfo { get; set; }
        public Statistics Statistics { get; set; }

        //TODO: Check for expected data relations
        //public List<CurrentBattle> CurrentBattles { get; set; }
    }
}
