using System.ComponentModel.DataAnnotations;

namespace Filer.Api.DTOs;

public record PostDto(int Id,string Tag, string Description, int UserId);
public record CreatePostDto([Required]string Tag, string Description, [Required]int UserId);