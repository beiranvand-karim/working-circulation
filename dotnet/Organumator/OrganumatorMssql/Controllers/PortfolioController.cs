using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrganumatorMssql.Extensions;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController(
        UserManager<AppUser> userManager,
        IStockRepository stockRepository,
        IPortfolioRepository portfolioRepository
        ) : ControllerBase
    {

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await userManager.FindByNameAsync(username);
            var userPortfolio = await portfolioRepository.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        } 
    }
}