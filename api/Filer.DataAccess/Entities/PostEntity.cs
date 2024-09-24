using System.ComponentModel.DataAnnotations;

namespace Filer.DataAccess;

public class PostEntity{
    [Key]
    public int Id { get; set;}
    [MinLength(3)]
    public string Tag { get; set;} = "";
}