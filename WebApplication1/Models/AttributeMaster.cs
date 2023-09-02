using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class AttributeMaster
{
    public long AttributeId { get; set; }

    public string? AttributeDesc { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}
