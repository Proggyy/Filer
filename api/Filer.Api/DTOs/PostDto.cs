using System.ComponentModel.DataAnnotations;

namespace Filer.Api.DTOs;

public record PostDto(int Id,string Tag, string Description);
public record CreatePostDto([Required]string Tag, string Description);