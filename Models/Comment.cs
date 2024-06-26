using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

[Table("Comments")]
public class Comment
{
    public int? Id { get; set; } // Navigation Property
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UnixEpoch;
    
    [ForeignKey(nameof(Stock))]
    public int? StockId { get; set; }
    public virtual Stock Stock { get; set; }
    public List<Portfolio> Portfolios { get; set; } = new();
}