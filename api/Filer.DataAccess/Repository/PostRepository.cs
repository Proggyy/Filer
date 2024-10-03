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
        await postContext.PostEntities.AddAsync(new PostEntity{Tag = entity.Tag,
         ImagePath = entity.ImagePath,
         Description = entity.Description,
         CreationDate = entity.CreationDate, 
         UserId = entity.Creator!.Id});
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
        var post = await postContext.PostEntities.Include(p => p.UserEntity).AsNoTracking().FirstAsync(p => p.Id == id);
        if (post != null)
        {
            return post.HasImage ? Post.CreatePost(post.Id, post.Tag!, post.ImagePath, post.Description, post.CreationDate, User.CreateUser(post.UserEntity!.Id, post.UserEntity.UserName!, post.UserEntity.Login!)) 
            : Post.CreatePostWithoutImage(post.Id, post.Tag!, post.Description, post.CreationDate, User.CreateUser(post.UserEntity!.Id, post.UserEntity.UserName!, post.UserEntity.Login!));
        }
        else{
            return new Post();
        }
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await postContext.PostEntities.Include(p => p.UserEntity).AsNoTracking()
        .Select(post => post.HasImage ? 
        Post.CreatePost(post.Id, post.Tag!, post.ImagePath, post.Description, post.CreationDate, User.CreateUser(post.UserEntity!.Id, post.UserEntity.UserName!, post.UserEntity.Login!)) 
            : Post.CreatePostWithoutImage(post.Id, post.Tag!, post.Description, post.CreationDate, User.CreateUser(post.UserEntity!.Id, post.UserEntity.UserName!, post.UserEntity.Login!)))
        .ToListAsync();
    }

    public async Task Update(Post entity)
    {
        var post = await postContext.PostEntities.FindAsync(entity.Id);        
        if(post != null){
            post.Tag = entity.Tag;
            post.ImagePath = entity.ImagePath;
            post.Description = entity.Description;
            post.UserId = entity.Creator!.Id;
            postContext.PostEntities.Update(post);
        }
        
    }
    public async Task Save(){
        await postContext.SaveChangesAsync();
    }
}