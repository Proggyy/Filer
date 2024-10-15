using System.Reflection;

namespace Filer.Domain.Common;

public static class Sortings<T>{
    public static IEnumerable<T> OrderByProp(IEnumerable<T> users, string query, Orders order)
    {
                if(string.IsNullOrWhiteSpace(query)){
            return users;
        }
        var classProp = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .FirstOrDefault(x => x.Name.Equals(query, StringComparison.InvariantCultureIgnoreCase));       
        if(classProp == null){
            return users;
        }
        switch(order){
            case Orders.Ascending:
            return users.Order(new PropertyComparer<T>(classProp));
            case Orders.Descending:
            return users.OrderDescending(new PropertyComparer<T>(classProp));
            default:
            return users.Order(new PropertyComparer<T>(classProp));
        }
    }
}