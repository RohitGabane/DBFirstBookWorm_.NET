using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cart
{
    public long CartId { get; set; }

    public int Quantity { get; set; }

    public string? Type { get; set; }

    public long? CustomerCustomerId { get; set; }

    public long? ProductProductId { get; set; }

    public virtual CustomerMaster? CustomerCustomer { get; set; }

    public virtual ProductMaster? ProductProduct { get; set; }
}
