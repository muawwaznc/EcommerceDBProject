using System;
using System.Collections.Generic;

namespace EcommerceDBProject.EcomDbContext;

public partial class ProductReturn
{
    public string ReturnId { get; set; } = null!;

    public string OrderItemId { get; set; } = null!;

    public DateTime? ReturnDate { get; set; }

    public string? ReturnReason { get; set; }

    public string ReturnStatus { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;
}
