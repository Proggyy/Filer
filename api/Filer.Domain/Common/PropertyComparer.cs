namespace Filer.Domain.Common;
using System.Reflection;

public class PropertyComparer<T> : IComparer<T>
{
    private PropertyInfo propertyInfo;
    public PropertyComparer(PropertyInfo propertyInfo)
    {
        this.propertyInfo = propertyInfo;
    }

    public int Compare(T? x, T? y)
    {
        switch(propertyInfo.PropertyType.Name){
            case "String": 
            return (propertyInfo.GetValue(x) as string)!.CompareTo((propertyInfo.GetValue(y) as string)!);
            case "Int32":
            return (int)propertyInfo.GetValue(x)! - (int)propertyInfo.GetValue(y)!;
            default: 
            return 0;
        }
            
    }
}