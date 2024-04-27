using EcommerceDBProject.NewF;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages
{
    public partial class CustomerDashboard : ComponentBase
    {
        #region Injection

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }

        #endregion
    }
}
