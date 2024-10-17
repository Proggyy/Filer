using Filer.Domain.Common;
using Filer.Domain.Domain;

namespace Filer.DataAccess.Extensions;

public static class PostRepositoryExtensions{
    public static IEnumerable<Post> Sort(this IEnumerable<Post> posts, string query){
        if(string.IsNullOrWhiteSpace(query) || string.IsNullOrEmpty(query))
        {
            return posts;
        }       
        return Sortings<Post>.OrderByProp(posts,query, Orders.Ascending);
    }
    public static IQueryable<PostEntity> Search(this IQueryable<PostEntity> posts, string searchTerm, bool withDescription){
        if(string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrEmpty(searchTerm))
        {
            return posts;
        }
        var optimizeTerm = searchTerm.Trim().ToLower();
        if(withDescription){
            return posts.Where(x => x.Tag!.ToLower().Contains(optimizeTerm) || x.Description!.ToLower().Contains(optimizeTerm));
        }
        return posts.Where(x => x.Tag!.ToLower().Contains(optimizeTerm));
    }
}