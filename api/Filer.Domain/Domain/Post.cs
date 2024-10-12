using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filer.Domain.Domain;

public class Post{
    [Key]
    public Guid Id { get; set;}
    [Required(ErrorMessage = "Tag is a required field.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tag can contain from 3 to 100 characters")]
    public string? Tag { get; set;}
    public bool HasImage => ImagePath != "";
    public string ImagePath { get; set;} = "";
    [MaxLength(500,ErrorMessage = "Maximum length for description is 500 characters.")]
    public string Description { get; set;} = "";
    [Required]
    public DateTimeOffset CreationDate { get; set; }
    [Required]
    public User? Creator { get; set; }

    public static Post CreatePost(Guid id, string tag, string imagePath, string description, DateTimeOffset createdate, User creator) 
    {
        return new Post{Id = id, Tag = tag, Description = description, CreationDate = createdate, ImagePath = imagePath, Creator = creator};
    }   
    public static Post CreatePostWithoutImage(Guid id, string tag, string description, DateTimeOffset createdate, User creator) 
    {
        return new Post{Id = id, Tag = tag, Description = description, CreationDate = createdate, Creator = creator};
    }  
}