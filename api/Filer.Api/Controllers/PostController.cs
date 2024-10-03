using Filer.Api.DTOs;
using Filer.Application.Interfaces;
using Filer.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IPostService postService;
        public PostController(IPostService postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var posts = await postService.GetAll();
            return Ok(posts.Select(post => new PostDto(post.Id,post.Tag!, post.Description, post.Creator!.Id)));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id){
            var post = await postService.Get(id);
            return Ok(new PostDto(post.Id,post.Tag!, post.Description, post.Creator!.Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePostDto postDto){
            var user = await userService.Get(postDto.UserId);
            if(user == null)
            {
                return NotFound();
            }
            await postService.Create(new Post{Tag = postDto.Tag, Description = postDto.Description, CreationDate = DateTimeOffset.Now.ToUniversalTime(), Creator = user});            
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] CreatePostDto postDto){
            var post = await postService.Get(id);
            if(post == null){
                return NotFound();              
            }
            var user = await userService.Get(postDto.UserId);
            if(user == null){
                return NotFound();              
            }
            post.Tag = postDto.Tag;
            post.Description = postDto.Description;
            post.Creator = user;
            await postService.Update(post);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id){
            await postService.Delete(id);
            return Ok();
        }

    }
}
