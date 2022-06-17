using SocialBets.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialBets.Domain.Core.Models
{
    public class OperationsHistoryItem : IEntity<int>
    {
        public int Id { get; set; }
        public int OperationMoney { get; set; }
        public OperationType OperationType { get; set; }
    }
}
