using System.Security.Cryptography;
using System.Text;
using DiagenVet.Core.DTOs.Auth;
using DiagenVet.Core.Entities.Concrete;
using DiagenVet.Core.Services;
using DiagenVet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DiagenVet.Core.Models;

namespace DiagenVet.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly DiagenVetContext _context;
        private readonly IJwtService _jwtService;
        private readonly JwtSettings _jwtSettings;

        public AuthService(DiagenVetContext context, IJwtService jwtService, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtService = jwtService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await GetUserByEmailAsync(loginDto.Email);
            if (user == null)
                throw new Exception("User not found");

            if (!VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Password is incorrect");

            var claims = await GetUserClaimsAsync(user);
            var token = _jwtService.GenerateToken(user, claims);

            return new TokenDto
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes)
            };
        }

        public async Task<TokenDto> RegisterAsync(RegisterDto registerDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == registerDto.Email);
            if (userExists)
                throw new Exception("User already exists");

            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                UserType = registerDto.UserType
            };

            await _context.Users.AddAsync(user);
            
            // Add default user claims
            var defaultClaim = await _context.OperationClaims.FirstOrDefaultAsync(c => c.Name == "User")
                ?? throw new Exception("Default claim not found");
            
            await _context.UserOperationClaims.AddAsync(new UserOperationClaim
            {
                User = user,
                OperationClaimId = defaultClaim.Id
            });

            await _context.SaveChangesAsync();

            var claims = await GetUserClaimsAsync(user);
            var token = _jwtService.GenerateToken(user, claims);

            return new TokenDto
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes)
            };
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IList<OperationClaim>> GetUserClaimsAsync(User user)
        {
            return await _context.UserOperationClaims
                .Where(uoc => uoc.UserId == user.Id)
                .Include(uoc => uoc.OperationClaim)
                .Select(uoc => uoc.OperationClaim)
                .ToListAsync();
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
} 