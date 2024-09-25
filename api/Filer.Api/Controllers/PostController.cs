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
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int id){
            var posts = await postService.GetAllPosts();
            return Ok(posts.Select(p => new PostDto{Id = p.Id, Tag = p.Tag}));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id){
            var post = await postService.GetPost(id);
            return Ok(new PostDto{Id = post.Id, Tag = post.Tag});
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePostDto postDto){
            await postService.CreatePost(new Post{Tag = postDto.Tag});            
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromQuery] int id,[FromBody] CreatePostDto postDto){
            var post = await postService.GetPost(id);
            if(post != null){
                post.Tag = postDto.Tag;

                await postService.UpdatePost(post);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id){
            await postService.DeletePost(id);
            return Ok();
        }

    }
}
