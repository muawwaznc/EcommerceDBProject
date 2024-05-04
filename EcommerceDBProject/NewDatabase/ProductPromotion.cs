using System;
using System.Collections.Generic;

namespace EcommerceDBProject.NewDatabase;

public partial class ProductPromotion
{
    public string ProductPromotionId { get; set; } = null!;

    public string PromotionId { get; set; } = null!;

    public string InventoryItemId { get; set; } = null!;

    public virtual InventoryItem InventoryItem { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
