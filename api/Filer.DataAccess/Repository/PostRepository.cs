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

    public async Task Create(Post entity)
    {
        await postContext.PostEntities.AddAsync(new PostEntity{Tag = entity.Tag});
    }

    public async Task Delete(int id)
    {
        var entity = await postContext.PostEntities.FindAsync(id);
        if(entity != null){
            postContext.PostEntities.Remove(entity);
        }
    }

    public async Task<Post> Get(int id)
    {
        var post = await postContext.PostEntities.FindAsync(id);
        if (post != null)
        {
            return post.HasImage ? Post.CreatePost(post.Id, post.Tag!, post.ImagePath, post.Description, post.CreationDate) 
            : Post.CreatePostWithoutImage(post.Id, post.Tag!, post.Description, post.CreationDate);
        }
        else{
            return new Post();
        }
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await postContext.PostEntities.AsNoTracking()
        .Select(post => post.HasImage ? 
        Post.CreatePost(post.Id, post.Tag!, post.ImagePath, post.Description, post.CreationDate) 
            : Post.CreatePostWithoutImage(post.Id, post.Tag!, post.Description, post.CreationDate))
        .ToListAsync();
    }

    public async Task Update(Post entity)
    {
        var post = await postContext.PostEntities.FindAsync(entity.Id);        
        if(post != null){
            post.Tag = entity.Tag;
            postContext.PostEntities.Update(post);
        }
        
    }
    public async Task Save(){
        await postContext.SaveChangesAsync();
    }
}