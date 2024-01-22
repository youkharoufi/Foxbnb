using FoxBnB.Models;

namespace FoxBnB.TokenService
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);

    }
}
