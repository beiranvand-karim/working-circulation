using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrganumatorMssql.Dtos.Account;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        public AccountController(UserManager<AppUser> _userManager,
            ITokenService _tokenService
            )
        {
            this.userManager = _userManager;
            this.tokenService = _tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]
        RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email

                };

                var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = tokenService.CreateToken(appUser)
                        }
                        );
                    }
                    else
                    {
                        StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

                return BadRequest();

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }
    }
}