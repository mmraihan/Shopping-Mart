using ShoppingMart.Core.Entities.Identity;

namespace ShoppingMart.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
