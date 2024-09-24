using Filer.Application.Interfaces;
using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
namespace Filer.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository postRepository;
    public PostService(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    public void CreatePost(Post post)
    {
        postRepository.Create(post);
        postRepository.Save();
    }

    public Post GetPost(int id)
    {
        return postRepository.Get(id);
    }
}