using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DatabaseContext;

public partial class ProductCategory
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
