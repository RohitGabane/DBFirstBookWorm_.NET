using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class MyShelf
{
    public long ShelfId { get; set; }

    public ulong IsActive { get; set; }

    public DateOnly? ProductExpiryDate { get; set; }

    public string? TranType { get; set; }

    public long? CustomerId { get; set; }

    public long? ProductId { get; set; }

    public virtual CustomerMaster? Customer { get; set; }

    public virtual ProductMaster? Product { get; set; }
}
