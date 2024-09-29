using Filer.Api.DTOs;
using Filer.Application.Interfaces;
using Filer.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var users = await userService.GetAll();
            return Ok(users.Select(user => new UserDto(user.Id,user.Login!, user.UserName!)));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id){
            var user = await userService.Get(id);
            return Ok(new UserDto(user.Id,user.Login!, user.UserName!));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserDto userDto){
            await userService.Create(new User{Login = userDto.Login, UserName = userDto.UserName});            
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] CreateUserDto userDto){
            var user = await userService.Get(id);
            if(user != null){
                user.Login = userDto.Login; 
                user.UserName = userDto.UserName; 

                await userService.Update(user);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id){
            await userService.Delete(id);
            return Ok();
        }
    }
}