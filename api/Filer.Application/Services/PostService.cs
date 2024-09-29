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
    public async Task Create(Post post)
    {
        await postRepository.Create(post);
        await postRepository.Save();
    }

    public async Task Delete(int id)
    {
        await postRepository.Delete(id);
        await postRepository.Save();
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await postRepository.GetAll();
    }

    public async Task<Post> Get(int id)
    {
        return await postRepository.Get(id);
    }

    public async Task Update(Post post)
    {
        await postRepository.Update(post);
        await postRepository.Save();
    }
}