using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContext;

public partial class Seller
{
    public string SellerId { get; set; } = null!;

    public string UserDetailId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? SellerRating { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual UserDetail UserDetail { get; set; } = null!;
}
