using DiagenVet.Core.Entities.Concrete;

namespace DiagenVet.Core.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user, IList<OperationClaim> operationClaims);
    }
} 