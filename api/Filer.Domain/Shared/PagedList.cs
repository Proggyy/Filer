namespace Filer.Domain.Shared;

public class PagedList<T> : List<T>{
    public PageData pagedata { get; set; }
    public PagedList(List<T> items, int count, int PageNumber, int pageSize)
    {
        pagedata = new PageData{
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = PageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };
        AddRange(items);
    }

    public static PagedList<T> CreatePagedList(IEnumerable<T> items, int pageNumber, int pageSize){
        var count = items.Count();
        var data = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(data, count, pageNumber,pageSize);
    }
}