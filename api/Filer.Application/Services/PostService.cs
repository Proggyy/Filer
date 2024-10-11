using Filer.Application.Interfaces;
using Filer.DataAccess;
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
        var existedUser = await postRepository.Get(post.Creator!.Id);
        if(existedUser.Id == 0){
            return;
        }
        await postRepository.Create(post);
        await postRepository.Save();
    }

    public async Task Delete(int id)
    {
        var post = await postRepository.Get(id);
        if(post.Id == 0){
            return;
        }
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
        var existedPost = await postRepository.Get(post.Id);
        if(existedPost.Id == 0){
            return;
        }
        var existedUser = await postRepository.Get(post.Creator!.Id);
        if(existedUser.Id == 0){
            return;
        }
        await postRepository.Update(post);
        await postRepository.Save();
    }
}