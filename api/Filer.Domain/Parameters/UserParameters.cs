namespace Filer.Domain.Parameters;

public class UserParameters : RequestParameters
{
    public UserParameters()
    {
        OrderBy = "username";
    }
}