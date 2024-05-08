using System;
using System.Collections.Generic;

namespace EcommerceDBProject.DBContext;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string UserDetailId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserDetail UserDetail { get; set; } = null!;
}
