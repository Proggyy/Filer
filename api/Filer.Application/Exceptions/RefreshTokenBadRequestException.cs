namespace Filer.Application.Exceptions;

public sealed class RefreshTokenBadRequestException : BadRequestException{
    public RefreshTokenBadRequestException() 
    : base("The tokenDto has invalid values.") { }
}