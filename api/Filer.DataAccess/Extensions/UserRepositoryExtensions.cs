using Filer.Domain.Common;
using Filer.Domain.Domain;

namespace Filer.DataAccess.Extensions;

public static class UserRepositoryExtensions{
    public static IEnumerable<User> Sort(this IEnumerable<User> users, string query){
        if(string.IsNullOrWhiteSpace(query) || string.IsNullOrEmpty(query))
        {
            return users;
        }       
        return Sortings<User>.OrderByProp(users,query, Orders.Ascending);
    }


}