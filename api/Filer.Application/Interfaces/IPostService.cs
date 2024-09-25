using Filer.Domain.Domain;

namespace Filer.Application.Interfaces;

public interface IPostService{
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPost(int id);
    Task CreatePost(Post post);
    Task DeletePost(int id);
    Task UpdatePost(Post post);
}