namespace Filer.Application.Exceptions;

public sealed class UserNotFoundException : NotFoundException{
    public UserNotFoundException(Guid id) 
    : base($"User with Id {id} not found in the database.") { }
}