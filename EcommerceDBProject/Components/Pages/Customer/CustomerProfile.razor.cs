using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Customer
{
    public partial class CustomerProfile
    {
        [Parameter] public string UserDetailId { get; set; }
        public string UserName { get; set; }
    }
}
