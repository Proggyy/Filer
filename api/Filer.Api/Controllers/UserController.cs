using System.Text.Json;
using AutoMapper;
using Filer.Api.DTOs;
using Filer.Api.Filters;
using Filer.Application.Interfaces;
using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "MinuteDuration")]
        public async Task<IActionResult> GetAll([FromQuery] UserParameters userParameters){
            var users = await userService.GetAll(userParameters);
            Response.Headers.Append("Pagination-Data", JsonSerializer.Serialize(users.pagedata));
            return Ok(mapper.Map<IEnumerable<UserDto>>(users));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id){
            var user = await userService.Get(id);
            if(user.Id == Guid.Empty){
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(user));
        }
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Create([FromBody]CreateUserDto userDto){
            await userService.Create(mapper.Map<User>(userDto));            
            return Ok();
        }
        [HttpPut("{id:guid}")]
        [ValidationFilter]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] CreateUserDto userDto){
            var user = await userService.Get(id);
            if(user.Id == Guid.Empty){
                return NotFound();
            }
            user.Login = userDto.Login; 
            user.UserName = userDto.UserName; 

            await userService.Update(user);
            return Ok();                     
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id){
            if((await userService.Get(id)).Id == Guid.Empty){
                return NotFound();
            }
            await userService.Delete(id);
            return Ok();
        }
    }
}