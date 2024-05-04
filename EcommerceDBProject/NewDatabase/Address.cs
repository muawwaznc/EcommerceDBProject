using System;
using System.Collections.Generic;

namespace EcommerceDBProject.NewDatabase;

public partial class Address
{
    public string AddressId { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
