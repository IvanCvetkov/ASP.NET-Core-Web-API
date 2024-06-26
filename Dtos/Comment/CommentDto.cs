namespace WebAPI.Dtos.Comment;

public class CommentDto
{
    public int? Id { get; set; } // Navigation Property
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UnixEpoch;
    
    public int? StockId { get; set; }
}