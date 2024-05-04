using EcommerceDBProject.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class ReturnOrder : ComponentBase
    {
        #region Injection

        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }

        #endregion

    }
}
