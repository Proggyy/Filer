using System.ComponentModel.DataAnnotations;

namespace Filer.Api.DTOs;

public record UserDto(Guid Id,string Login, string UserName);
public record CreateUserDto([Required]string Login, [Required]string UserName);