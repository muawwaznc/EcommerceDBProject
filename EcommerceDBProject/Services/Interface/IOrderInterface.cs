using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderInterface
    {
        void PlaceOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList, CustomerDetailViewModel customerDetail);
    }
}
