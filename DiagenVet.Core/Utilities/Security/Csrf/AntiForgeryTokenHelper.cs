using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace DiagenVet.Core.Utilities.Security.Csrf
{
    public class AntiForgeryTokenHelper
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryTokenHelper(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public string GenerateToken(HttpContext context)
        {
            var tokens = _antiforgery.GetAndStoreTokens(context);
            return tokens.RequestToken;
        }

        public async Task ValidateToken(HttpContext context)
        {
            await _antiforgery.ValidateRequestAsync(context);
        }
    }
} 