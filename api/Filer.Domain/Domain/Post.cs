using System.ComponentModel.DataAnnotations;

namespace Filer.Domain.Domain;

public class Post{
    [Key]
    public int Id { get; set;}
    [MinLength(3)]
    public string Tag { get; set;} = "";
    public static Post CreatePost(int id, string tag) 
    {
        return new Post{Id = id, Tag = tag};
    }   
}