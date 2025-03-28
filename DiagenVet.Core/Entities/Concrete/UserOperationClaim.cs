using System;
using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
} 