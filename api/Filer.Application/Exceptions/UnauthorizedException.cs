namespace Filer.Application.Exceptions;

public class UnauthorizedException : Exception{
    public UnauthorizedException() : base("Incorrect login or password. Change the entered data and try again."){}
}