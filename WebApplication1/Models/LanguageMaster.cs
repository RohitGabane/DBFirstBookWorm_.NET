using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LanguageMaster
{
    public long LanguageId { get; set; }

    public string? LanguageDesc { get; set; }

    public long? TypeId { get; set; }

    public virtual ICollection<GenreMaster> GenreMasters { get; set; } = new List<GenreMaster>();

    public virtual ICollection<ProductMaster> ProductMasters { get; set; } = new List<ProductMaster>();

    public virtual ProductTypeMaster? Type { get; set; }
}
