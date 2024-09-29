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
        public async Task<IActionResult> GetAll(){
            var posts = await postService.GetAll();
            return Ok(posts.Select(post => new PostDto(post.Id,post.Tag!, post.Description)));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id){
            var post = await postService.Get(id);
            return Ok(new PostDto(post.Id,post.Tag!, post.Description));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePostDto postDto){
            await postService.Create(new Post{Tag = postDto.Tag, Description = postDto.Description, CreationDate = DateTimeOffset.Now});            
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] CreatePostDto postDto){
            var post = await postService.Get(id);
            if(post != null){
                post.Tag = postDto.Tag;

                await postService.Update(post);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id){
            await postService.Delete(id);
            return Ok();
        }

    }
}
