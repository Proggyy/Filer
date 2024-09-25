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
    public async Task CreatePost(Post post)
    {
        await postRepository.Create(post);
        await postRepository.Save();
    }

    public async Task DeletePost(int id)
    {
        await postRepository.Delete(id);
        await postRepository.Save();
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await postRepository.GetAll();
    }

    public async Task<Post> GetPost(int id)
    {
        return await postRepository.Get(id);
    }

    public async Task UpdatePost(Post post)
    {
        await postRepository.Update(post);
        await postRepository.Save();
    }
}