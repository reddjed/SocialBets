using System;
using System.Collections.Generic;
using System.Text;

namespace SocialBets.Domain.Core.Interfaces
{
    public interface IEntity<T>
        where T : struct
    {
        public T Id { get; set; }
    }
}
