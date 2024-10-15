namespace Filer.Domain.Parameters;

public class PostParameters : RequestParameters
{
    public PostParameters()
    {
        OrderBy = "tag";
    }
}