namespace Filer.Application.Exceptions;

public sealed class UserNotFoundException : NotFoundException{
    public UserNotFoundException(int id) 
    : base($"User with Id {id} not found in the database.") { }
}