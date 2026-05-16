using OrganumatorMssql.Models;

namespace OrganumatorMssql.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}