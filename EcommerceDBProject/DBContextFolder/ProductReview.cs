using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContextFolder;

public partial class ProductReview
{
    public string ReviewId { get; set; } = null!;

    public string OrderItemId { get; set; } = null!;

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;
}
