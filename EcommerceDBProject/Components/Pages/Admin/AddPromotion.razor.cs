using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class AddPromotion
    {
        #region Injection

        [Inject] IPromotionInterface PromotionService { get; set; }

        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        protected Promotion Promotion { get; set; } = new();

        #endregion

        #region OnClick Functions

        protected void AddProductPromotion()
        {
            if (Promotion.PromotionName == null)
            {
                ToastService.ShowError("Enter Promotion name");
            }
            else if (Promotion.DiscountPercentage == 0)
            {
                ToastService.ShowError("Enter Discount Percentage");
            }
            else if (Promotion.StartDate == null)
            {
                ToastService.ShowError("Enter Start Date");
            }
            else if (Promotion.EndDate == null)
            {
                ToastService.ShowError("Enter End Date");
            }
            if(Promotion.EndDate < Promotion.StartDate)
            {
                ToastService.ShowError("Enter a Valid Start and End Date");
            }
            else if (Promotion.PromotionDescription == null)
            {
                ToastService.ShowError("Enter Promotion Description");
            }
            else
            {
                if (!PromotionService.IsPromotionNameAlreadyExist(Promotion))
                {
                    PromotionService.AddPromotion(Promotion);
                    ToastService.ShowSuccess("Promotion Added Successfully");
                }
                else
                {
                    ToastService.ShowError("Promotion is Already Exist");
                }
            }
        }

        #endregion

    }
}
