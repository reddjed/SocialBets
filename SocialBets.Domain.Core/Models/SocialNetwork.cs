using System;
using System.Collections.Generic;
using System.Text;

using SocialBets.Domain.Core.Interfaces;

namespace SocialBets.Domain.Core.Models
{
    public class SocialNetwork : IEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        //public string OembedUrl { get; set; }
    }
}
