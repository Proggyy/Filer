namespace Filer.Application.Exceptions;

public sealed class PostNotFoundException : NotFoundException{
    public PostNotFoundException(int id) 
    : base($"Post with Id {id} not found in the database.") { }
}