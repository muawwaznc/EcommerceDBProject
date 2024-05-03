using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderInterface
    {
        void PlaceOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList, CustomerDetailViewModel customerDetail);
        List<CustomerOrdersViewModel> GetCustomerOrdersViewModelList(string userDetailId);
        List<Order> GetOrdersListFromCustomerId(string customerId);
        List<OrderItem> GetOrderItemsListFromOrderId(string orderId);
        List<SellerOrdersViewModel> GetSellerOrdersViewModelList(string userDetailId);
        void ShipOrder(string orderItemId);
    }
}
