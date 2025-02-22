namespace Filer.Domain.Shared;

public class PageData{
    public int TotalCount { get; set; }
    public int PageSize { get; set;}
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}