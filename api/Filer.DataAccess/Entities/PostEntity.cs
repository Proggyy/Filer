using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filer.DataAccess;

public class PostEntity{
    [Key]
    public int Id { get; set;}
    [Required(ErrorMessage = "Tag is a required field.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The tag can contain from 3 to 100 characters")]
    public string? Tag { get; set;}
    [NotMapped]
    public bool HasImage => ImagePath != "";
    public string ImagePath { get; set;} = "";
    [MaxLength(500,ErrorMessage = "Maximum length for description is 500 characters.")]
    public string Description { get; set;} = "";
    [Required]
    public DateTimeOffset CreationDate { get; set; }
    [ForeignKey(nameof(UserEntity))]
    public int UserId { get; set; }
    public UserEntity? UserEntity { get; set; }
}