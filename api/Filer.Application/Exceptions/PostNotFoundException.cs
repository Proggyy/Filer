namespace Filer.Application.Exceptions;

public sealed class PostNotFoundException : NotFoundException{
    public PostNotFoundException(Guid id) 
    : base($"Post with Id {id} not found in the database.") { }
}