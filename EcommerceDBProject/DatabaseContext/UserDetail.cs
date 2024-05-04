using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DatabaseContext;

public partial class UserDetail
{
    public string UserDetailId { get; set; } = null!;

    public string? AddressId { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Picture { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Seller? Seller { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
