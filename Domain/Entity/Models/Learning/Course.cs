using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("courses", Schema = "learning")]
public class Course : AuditableModelBase<long>
{
    [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("image")]
    public string Image { get; set; }

    [Column("language_code")]
    public string LanguageCode { get; set; } = "uz";

    [Column("author_id")]
    [ForeignKey(nameof(Author))]
    public long AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    [Column("category_id")]
    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}