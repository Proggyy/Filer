namespace Filer.Application.Exceptions;

public sealed class LoginExistException : BadRequestException{
    public LoginExistException(string login) 
    : base($"User with login {login} already exists.") { }
}