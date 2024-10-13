using System.ComponentModel.DataAnnotations;
using Filer.Domain.Domain;

namespace Filer.Api.DTOs;

public record PostDto(Guid Id,string Tag, string ImagePath,string Description, DateTimeOffset CreationDate, UserDto Creator);
public record CreatePostDto([Required][StringLength(100, MinimumLength = 3, ErrorMessage = "Tag can contain from 3 to 100 characters")]string Tag, string ImagePath,[MaxLength(500,ErrorMessage = "Maximum length for description is 500 characters.")]string Description, [Required]Guid UserId);