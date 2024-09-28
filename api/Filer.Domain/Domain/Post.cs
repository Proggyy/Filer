using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filer.Domain.Domain;

public class Post{
    [Key]
    public int Id { get; set;}
    [Required(ErrorMessage = "Tag is a required field.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The tag can contain from 3 to 100 characters")]
    public string? Tag { get; set;}
    public bool HasImage => ImagePath != "";
    public string ImagePath { get; set;} = "";
    [MaxLength(500,ErrorMessage = "Maximum length for description is 500 characters.")]
    public string Description { get; set;} = "";
    [Required]
    public DateTimeOffset CreationDate { get; set; }

    public static Post CreatePost(int id, string tag, string imagePath, string description, DateTimeOffset createdate) 
    {
        return new Post{Id = id, Tag = tag, Description = description, CreationDate = createdate, ImagePath = imagePath};
    }   
    public static Post CreatePostWithoutImage(int id, string tag, string description, DateTimeOffset createdate) 
    {
        return new Post{Id = id, Tag = tag, Description = description, CreationDate = createdate};
    }  
}