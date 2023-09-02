using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class PublisherMaster
{
    public long PublisherId { get; set; }

    public string? PublisherContactNo { get; set; }

    public string? PublisherName { get; set; }

    public virtual ICollection<ProductMaster> ProductMasters { get; set; } = new List<ProductMaster>();
}
