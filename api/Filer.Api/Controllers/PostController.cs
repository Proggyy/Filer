using System.ComponentModel.DataAnnotations;
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
    public class PostController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        private readonly IMapper mapper;
        public PostController(IPostService postService, IUserService userService, IMapper mapper)
        {
            this.postService = postService;
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "MinuteDuration")]
        public async Task<IActionResult> GetAll([FromQuery] PostParameters postParameters){
            var posts = await postService.GetAll(postParameters);
            Response.Headers.Append("Pagination-Data", JsonSerializer.Serialize(posts.pagedata));
            return Ok(mapper.Map<IEnumerable<PostDto>>(posts));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id){
            var post = await postService.Get(id);
            if(post.Id == Guid.Empty){
                return NotFound();
            }
            return Ok(mapper.Map<PostDto>(post));
        }
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Create([FromBody]CreatePostDto postDto){
            var user = await userService.Get(postDto.UserId);
            if(user.Id == Guid.Empty)
            {
                return NotFound();
            }
            var post = mapper.Map<Post>(postDto);
            post.Creator = user;
            await postService.Create(post);            
            return Ok();
        }
        [HttpPut("{id:guid}")]
        [ValidationFilter]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] CreatePostDto postDto){
            var post = await postService.Get(id);
            if(post.Id == Guid.Empty){
                return NotFound();              
            }
            var user = await userService.Get(postDto.UserId);
            if(user.Id == Guid.Empty){
                return NotFound();              
            }
            post.Tag = postDto.Tag;
            post.Description = postDto.Description;
            post.Creator = user;
            await postService.Update(post);
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id){
            if((await postService.Get(id)).Id == Guid.Empty){
                return NotFound();
            }
            await postService.Delete(id);
            return Ok();
        }

    }
}
