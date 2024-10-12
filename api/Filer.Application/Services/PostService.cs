using Filer.Application.Exceptions;
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
            throw new UserNotFoundException(post.Creator!.Id);
        }
        await postRepository.Create(post);
        await postRepository.Save();
    }

    public async Task Delete(int id)
    {
        var post = await postRepository.Get(id);
        if(post.Id == 0){
            throw new PostNotFoundException(id);
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
        var post = await postRepository.Get(id);
        if(post.Id == 0)
        {
            throw new PostNotFoundException(id);
        }
        return post;
    }

    public async Task Update(Post post)
    {
        var existedPost = await postRepository.Get(post.Id);
        if(existedPost.Id == 0){
            throw new PostNotFoundException(post.Id);
        }
        var existedUser = await postRepository.Get(post.Creator!.Id);
        if(existedUser.Id == 0){
            throw new UserNotFoundException(post.Creator!.Id);
        }
        await postRepository.Update(post);
        await postRepository.Save();
    }
}