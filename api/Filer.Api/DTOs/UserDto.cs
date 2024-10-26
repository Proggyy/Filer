using System.ComponentModel.DataAnnotations;

namespace Filer.Api.DTOs;

public record UserDto(Guid Id,string Login, string UserName);
public record CreateUserDto([Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]string Login, [Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]string UserName);
public record RegisterUserDto([Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]string Login, [Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]string UserName, [Required][StringLength(25, MinimumLength = 5, ErrorMessage = "Password can contain from 5 to 25 characters")]string Password);
public record LoginUserDto([Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]string Login, [Required][StringLength(25, MinimumLength = 5, ErrorMessage = "Password can contain from 5 to 25 characters")]string Password);