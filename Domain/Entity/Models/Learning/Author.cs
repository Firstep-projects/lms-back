using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Auth;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("authors", Schema = "learning")]
public class Author : AuditableModelBase<long>
{
    [Column("name")]
    public string Name { get; set; }
    [Column("content")]
    public string Content { get; set; }
    [Column("image_link")] 
    public string ImageLink { get; set; }

    // [Column("user_id")]
    // [ForeignKey(nameof(User))]
    // public long UserId { get; set; }
    // public virtual User User { get; set; }
    [NotMapped]public virtual ICollection<Course> Courses { get; set; }
    [NotMapped]public virtual ICollection<Article> Articles { get; set; }
    [NotMapped]public virtual ICollection<ShortVideo> ShortVideos { get; set; }
    [NotMapped]public virtual ICollection<SeminarVideo> SeminarVideos { get; set; }
}
