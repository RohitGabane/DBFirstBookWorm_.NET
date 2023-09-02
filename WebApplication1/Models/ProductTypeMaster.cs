using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ProductTypeMaster
{
    public long TypeId { get; set; }

    public string? TypeDesc { get; set; }

    public virtual ICollection<LanguageMaster> LanguageMasters { get; set; } = new List<LanguageMaster>();

    public virtual ICollection<ProductMaster> ProductMasters { get; set; } = new List<ProductMaster>();
}
