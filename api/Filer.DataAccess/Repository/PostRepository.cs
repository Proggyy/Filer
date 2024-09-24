using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Filer.DataAccess.Repository;

public class PostRepository : IPostRepository{
    private readonly PostContext postContext;
    public PostRepository(PostContext postContext)
    {
        this.postContext = postContext;
    }

    public void Create(Post entity)
    {
        postContext.PostEntities.Add(new PostEntity{Tag = entity.Tag});
    }

    public void Delete(int id)
    {
        var entity = postContext.PostEntities.Find(id);
        if(entity != null){
            postContext.PostEntities.Remove(entity);
        }
    }

    public Post Get(int id)
    {
        var post = postContext.PostEntities.Find(id);
        if (post != null)
        {
            return Post.CreatePost(post.Id, post.Tag);
        }
        else{
            return new Post();
        }
    }

    public IEnumerable<Post> GetAll()
    {
        return postContext.PostEntities.AsNoTracking().Select(p => Post.CreatePost(p.Id, p.Tag));
    }

    public void Update(Post entity)
    {
        var post = postContext.PostEntities.Find(entity.Id);        
        if(post != null){
            post.Tag = entity.Tag;
            postContext.PostEntities.Update(post);
        }
        
    }
    public void Save(){
        postContext.SaveChanges();
    }
}