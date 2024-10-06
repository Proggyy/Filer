using System.ComponentModel.DataAnnotations;
using Filer.Domain.Domain;

namespace Filer.Api.DTOs;

public record PostDto(int Id,string Tag, string ImagePath,string Description, DateTimeOffset CreationDate, UserDto Creator);
public record CreatePostDto([Required]string Tag, string ImagePath,string Description, [Required]int UserId);