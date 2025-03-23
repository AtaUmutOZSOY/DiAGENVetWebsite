using DiagenVet.Core.Entities.Enums;

namespace DiagenVet.Core.DTOs.Auth
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
} 