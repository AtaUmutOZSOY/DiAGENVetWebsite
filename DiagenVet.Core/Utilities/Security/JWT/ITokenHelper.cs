using DiagenVet.Core.Entities.Concrete;

namespace DiagenVet.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
} 