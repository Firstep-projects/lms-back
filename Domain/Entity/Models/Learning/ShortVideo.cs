using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("short_video", Schema = "learning")]
public class ShortVideo : AuditableModelBase<long>
{
    [Column("video_linc")]
    public string VideoLinc { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("author_id")]
    [ForeignKey(nameof(Author))]
    public long AuthorId { get; set; }
    public virtual Author? Author { get; set; }

    [Column("category_id")]
    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}