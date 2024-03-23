using Microsoft.AspNetCore.Identity;

namespace GMP.API.Repositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
