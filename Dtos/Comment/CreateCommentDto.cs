using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.Comment;

public class CreateCommentDto
{
    //[MinLength(100)]
    [Required]
    [MinLength(5, ErrorMessage = "Title must be atleast 5 characters long!")]
    [MaxLength(300, ErrorMessage = "Title cannot be over 300 characters long!")]

public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Content must be atleast 5 characters long!")]
    [MaxLength(300, ErrorMessage = "Content cannot be over 300 characters long!")]
    public string Content { get; set; } = string.Empty;
}