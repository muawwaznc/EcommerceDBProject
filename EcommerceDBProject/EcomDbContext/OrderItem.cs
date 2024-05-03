using System;
using System.Collections.Generic;

namespace EcommerceDBProject.EcomDbContext;

public partial class OrderItem
{
    public string OrderItemId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string InventoryItemId { get; set; } = null!;

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public bool IsReturned { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateTime RequiredShippingDate { get; set; }

    public DateTime? ShippingDate { get; set; }

    public virtual InventoryItem InventoryItem { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ProductReturn? ProductReturn { get; set; }

    public virtual ProductReview? ProductReview { get; set; }
}
