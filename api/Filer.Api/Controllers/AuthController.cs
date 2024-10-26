using Filer.Api.DTOs;
using Filer.Api.Filters;
using Filer.Application.Interfaces;
using Filer.Domain.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase{
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("register")]
        [ValidationFilter]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto){
            await userService.RegisterNewUser(registerUserDto.Login,registerUserDto.UserName,registerUserDto.Password);
            var users = await userService.GetAll(new UserParameters());
            return Ok(users);
        }
        [HttpPost("login")]
        [ValidationFilter]
        public async Task<IActionResult> Login(LoginUserDto registerUserDto){
            var token = await userService.LoginUser(registerUserDto.Login,registerUserDto.Password);
            if(token == ""){
                return NotFound();
            }
            Response.Cookies.Append("AuthToken", token);
            return Ok(token);
        }
    }
}