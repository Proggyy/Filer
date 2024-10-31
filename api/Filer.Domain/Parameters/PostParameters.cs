namespace Filer.Domain.Parameters;

public class PostParameters : RequestParameters
{
    public Guid UserId { get; set; } = Guid.Empty;
    public PostParameters()
    {
        OrderBy = "tag";
    }
}