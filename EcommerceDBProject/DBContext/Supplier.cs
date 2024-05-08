using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContext;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string UserDetailId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string ContactPersonName { get; set; } = null!;

    public string ContactPersonPhoneNumber { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual UserDetail UserDetail { get; set; } = null!;
}
