using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class Products : ComponentBase
    {
        #region Injection

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        public string UserName { get; set; }

        #endregion
    }
}
