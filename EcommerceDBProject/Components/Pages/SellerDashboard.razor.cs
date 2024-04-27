using EcommerceDBProject.NewF;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages
{
    public partial class SellerDashboard : ComponentBase
    {
        #region Injection

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }

        #endregion
    }
}
