using Filer.Api.DTOs;
using Filer.Api.Filters;
using Filer.Application.Interfaces;
using Filer.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase{
        private readonly IUserService userService;
        private readonly IAuthService authService;
        public AuthController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }
        [HttpPost("register")]
        [ValidationFilter]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto){
            bool isSucces = await authService.RegisterNewUser(registerUserDto.Login,registerUserDto.UserName,registerUserDto.Password);
            return Ok(isSucces);
        }
        [HttpPost("login")]
        [ValidationFilter]
        public async Task<IActionResult> Login(LoginUserDto registerUserDto){
            var token = await authService.LoginUser(registerUserDto.Login,registerUserDto.Password);
            return Ok(token);
        }
        [HttpGet("whoami")]
        [Authorize]
        public async Task<IActionResult> WhoAmI(){
            var UserIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Id");
            var userId = new Guid();
            if(UserIdClaim == null || !Guid.TryParse(UserIdClaim.Value, out userId))
            {
                return NotFound();
            }
            
            var user = await userService.Get(userId);
            if(user.Id == Guid.Empty){
                return NotFound();
            }
            return Ok(user.Login);
        }

        [HttpPost("refresh")]
        [ValidationFilter]
        public async Task<IActionResult> Resfresh([FromBody] TokenDto tokenDto){
            var token = await authService.Refresh(tokenDto);
            return Ok(token);
        }
    }
}