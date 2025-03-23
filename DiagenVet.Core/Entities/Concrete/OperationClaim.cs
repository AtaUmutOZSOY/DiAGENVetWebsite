using System;
using System.Collections.Generic;
using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
} 