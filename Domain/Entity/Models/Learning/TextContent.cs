﻿using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Common;

namespace Entity.Models.Learning;

[Table("test_contents", Schema = "learning")]
public class TextContent : AuditableModelBase<int>
{
    [Column("content")]
    public string Content { get; set; }
    
    public virtual CourseItem CourseItem { get; set; }
}