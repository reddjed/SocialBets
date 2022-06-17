using System;
using System.Collections.Generic;
using System.Text;

using SocialBets.Domain.Core.Interfaces;

namespace SocialBets.Domain.Core.Models
{
    /*enum OperationType
    {
        Income, Withdrawal, Bet
    }*/

    public class OperationType : IEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
