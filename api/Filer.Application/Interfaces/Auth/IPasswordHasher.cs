namespace Filer.Application.Interfaces.Auth;

public interface IPasswordHasher{
    string Hash(string password);
}