using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContext;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public string CategoryId { get; set; } = null!;

    public double Price { get; set; }

    public string? SupplierId { get; set; }

    public double? ProductWeight { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual Supplier? Supplier { get; set; }
}
