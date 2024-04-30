using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerPromotion
    {
        [Inject] IPromotionInterface PromotionService { get; set; }
        List<Promotion> PromotionList = new List<Promotion>();
        #region Load Initials

        protected override void OnInitialized()
        {
            PromotionList = PromotionService.GetAllProductPromotion();
        }


        #endregion

    }
}
