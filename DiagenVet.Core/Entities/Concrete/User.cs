using System;
using System.Collections.Generic;
using DiagenVet.Core.Entities.Abstract;
using DiagenVet.Core.Entities.Enums;

namespace DiagenVet.Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public UserType UserType { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
    }
} 