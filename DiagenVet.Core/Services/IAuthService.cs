using DiagenVet.Core.DTOs.Auth;
using DiagenVet.Core.Entities.Concrete;

namespace DiagenVet.Core.Services
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task<TokenDto> RegisterAsync(RegisterDto registerDto);
        Task<User> GetUserByEmailAsync(string email);
        Task<IList<OperationClaim>> GetUserClaimsAsync(User user);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
} 