using System.ComponentModel.DataAnnotations;

namespace Filer.DataAccess;

public class UserEntity{
    [Key]
    public int Id { get; set;}
    [Required(ErrorMessage = "Username is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]
    public string? UserName { get; set;}
    [Required(ErrorMessage = "Login is a required field.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]
    public string? Login { get; set;}
}