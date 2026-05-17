using Microsoft.AspNetCore.Identity;

namespace OrganumatorMssql.Models
{
    public class AppUser: IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = [];
    }
}