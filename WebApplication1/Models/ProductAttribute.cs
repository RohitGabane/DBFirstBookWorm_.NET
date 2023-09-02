using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ProductAttribute
{
    public long ProdAttId { get; set; }

    public string? AttributeValue { get; set; }

    public long? AttributeId { get; set; }

    public long? ProductId { get; set; }

    public virtual AttributeMaster? Attribute { get; set; }

    public virtual ProductMaster? Product { get; set; }
}
