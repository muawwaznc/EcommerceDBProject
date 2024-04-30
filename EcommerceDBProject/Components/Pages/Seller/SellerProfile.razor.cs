using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerProfile : ComponentBase
    {
        [Parameter] public string UserDetailId { get; set; }
        public string UserName { get; set; }
    }
}
