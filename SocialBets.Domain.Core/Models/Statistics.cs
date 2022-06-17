using SocialBets.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialBets.Domain.Core.Models
{
    public class Statistics : IEntity<int>
    {
        public int Id { get; set; }
        public int WinsCount { get; set; }
        public int LosesCount { get; set; }
        
    }
}
