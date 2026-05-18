using System.Security.Claims;

namespace OrganumatorMssql.Extensions
{
    public static class ClainExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user
            .Claims
            .SingleOrDefault(x => x
            .Type
            .Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        }
    }
}