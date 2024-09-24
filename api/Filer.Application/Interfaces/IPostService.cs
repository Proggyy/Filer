using Filer.Domain.Domain;

namespace Filer.Application.Interfaces;

public interface IPostService{
    Post GetPost(int id);
    void CreatePost(Post post);
}