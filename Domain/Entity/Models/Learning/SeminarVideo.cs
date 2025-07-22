using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("seminar_video", Schema = "learning")]
public class SeminarVideo : AuditableModelBase<long>
{
    [Column("video_linc")]
    public string VideoLinc { get; set; }

    [Column("title")]
    public MultiLanguageField Title { get; set; }

    [Column("author_id")]
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    [Column("category_id")]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}