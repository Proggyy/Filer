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


}