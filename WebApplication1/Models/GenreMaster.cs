using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class GenreMaster
{
    public long GenreId { get; set; }

    public string? GenreDesc { get; set; }

    public long? LanguageId { get; set; }

    public virtual LanguageMaster? Language { get; set; }

    public virtual ICollection<ProductMaster> ProductMasters { get; set; } = new List<ProductMaster>();
}
