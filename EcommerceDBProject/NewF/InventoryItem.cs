using System;
using System.Collections.Generic;

namespace EcommerceDBProject.NewF;

public partial class InventoryItem
{
    public string InventoryItemId { get; set; } = null!;

    public string SellerId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public double SalePrice { get; set; }

    public int StockAmount { get; set; }

    public string? Condition { get; set; }

    public virtual ICollection<InventoryItemPicture> InventoryItemPictures { get; set; } = new List<InventoryItemPicture>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
