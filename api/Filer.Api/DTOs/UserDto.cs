using System.ComponentModel.DataAnnotations;

namespace Filer.Api.DTOs;

public record UserDto(Guid Id,string Login, string UserName);
public record CreateUserDto([Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Login can contain from 3 to 50 characters")]string Login, [Required][StringLength(50, MinimumLength = 3, ErrorMessage = "Username can contain from 3 to 50 characters")]string UserName);