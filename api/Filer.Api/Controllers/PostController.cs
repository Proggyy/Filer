using Filer.Api.DTOs;
using Filer.Application.Interfaces;
using Filer.Domain.Domain;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get(int id){
            var post = postService.GetPost(id);
            return Ok(new PostDto{Id = post.Id, Tag = post.Tag});
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreatePostDto createPostDto){
            postService.CreatePost(new Post{Tag = createPostDto.Tag});            
            return Ok();
        }
    }
}
