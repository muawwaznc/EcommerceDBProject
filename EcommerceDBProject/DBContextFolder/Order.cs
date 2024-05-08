using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContextFolder;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public string ShippingAddressId { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Address ShippingAddress { get; set; } = null!;
}
