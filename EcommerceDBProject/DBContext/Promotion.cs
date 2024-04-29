using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContext;

public partial class Promotion
{
    public string PromotionId { get; set; } = null!;

    public string PromotionName { get; set; } = null!;

    public string? PromotionDescription { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double DiscountPercentage { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}
