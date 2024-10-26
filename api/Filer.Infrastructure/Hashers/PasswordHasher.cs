using System.Security.Cryptography;
using System.Text;
using Filer.Application.Interfaces.Auth;

namespace Filer.Infrastructure.Hashers;
public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using var hasher = SHA256.Create();
        byte[] hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
        var stringBuilder = new StringBuilder();
        foreach(var c in hash){
            stringBuilder.Append(c.ToString("X2"));
        }
        return stringBuilder.ToString();
    }
}