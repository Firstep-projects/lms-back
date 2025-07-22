using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("categories", Schema = "learning")]
public class Category : AuditableModelBase<long>
{
    [Column("title")]
    public MultiLanguageField Title { get; set; }

    [Column("description")] 
    public MultiLanguageField Description { get; set; }

    [Column("image_link")]
    public string ImageLink { get; set; }
}