using System;
using System.Collections.Generic;

namespace EcommerceDBProject.EcomDbContext;

public partial class InventoryItemPicture
{
    public string PictureId { get; set; } = null!;

    public string PictureUrl { get; set; } = null!;

    public string InventoryItemId { get; set; } = null!;

    public virtual InventoryItem InventoryItem { get; set; } = null!;
}
