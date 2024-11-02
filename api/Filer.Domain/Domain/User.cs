using System.ComponentModel.DataAnnotations;

namespace Filer.Domain.Domain;

public class User{
    [Key]
    public Guid Id { get; set;}
    [Required(ErrorMessage = "Username is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]
    public string? UserName { get; set;}
    [Required(ErrorMessage = "Login is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]
    public string? Login { get; set;}
    [Required]
    public string? PasswordHash { get; set;}
    public string? RefreshToken { get; set; }
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public static User CreateUser(Guid id, string userName, string login){
        return new User{Id = id, UserName = userName,Login = login};
    }
    public static User CreateNewUser(Guid id, string userName, string login, string passwordHash)
    {
        return new User{Id = id, UserName = userName,Login = login, PasswordHash = passwordHash};
    }

    public static User CreateLoginUser(Guid id, string userName, string login, string passwordHash, string refreshToken, DateTimeOffset? expiryDate)
    {
        return new User{Id = id, UserName = userName,Login = login, PasswordHash = passwordHash, RefreshToken = refreshToken, RefreshTokenExpiryTime = expiryDate};
    }
}