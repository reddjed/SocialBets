using SocialBets.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialBets.Domain.Core.Models
{
    public class UserInfo : IEntity<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
