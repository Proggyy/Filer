using System.Reflection;

namespace Filer.Domain.Common;

public static class Sortings<T>{
    public static IEnumerable<T> OrderByProp(IEnumerable<T> items, string query, Orders order)
    {
        if(string.IsNullOrWhiteSpace(query)){
            return items;
        }
        var classProp = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .FirstOrDefault(x => x.Name.Equals(query, StringComparison.InvariantCultureIgnoreCase));       
        if(classProp == null){
            return items;
        }
        switch(order){
            case Orders.Ascending:
            return items.Order(new PropertyComparer<T>(classProp));
            case Orders.Descending:
            return items.OrderDescending(new PropertyComparer<T>(classProp));
            default:
            return items.Order(new PropertyComparer<T>(classProp));
        }
    }
}