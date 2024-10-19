namespace Filer.Domain.Parameters;

public class RequestParameters{
    const int maxSize = 50;
    private int pageSize = 10;
    public int PageSize 
    { 
        get{ return pageSize;} 
        set{ pageSize = value > maxSize ? maxSize : value;} 
    }
    public int PageNumber { get; set; } = 1;
    public string? OrderBy { get; set; }
    public string SearchTerm { get; set; } = "";
}