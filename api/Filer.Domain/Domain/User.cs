using System.ComponentModel.DataAnnotations;

namespace Filer.Domain.Domain;

public class User{
    [Key]
    public int Id { get; set;}
    [Required(ErrorMessage = "Username is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]
    public string? UserName { get; set;}
    [Required(ErrorMessage = "Login is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]
    public string? Login { get; set;}

    public static User CreateUser(int id, string userName, string login){
        return new User{Id = id, UserName = userName,Login = login};
    }
}