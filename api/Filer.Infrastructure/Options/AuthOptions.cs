namespace Filer.Infrastructure.Options;

public class AuthOptions{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresHours { get; set; }
}