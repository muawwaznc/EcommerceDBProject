using EcommerceDBProject.DBContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderInterface
    {
        void PlaceOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList, CustomerDetailViewModel customerDetail);
        List<CustomerOrdersViewModel> GetCustomerOrdersViewModelList(string userDetailId);
        List<Order> GetOrdersListFromCustomerId(string customerId);
        List<OrderItem> GetOrderItemsListFromOrderId(string orderId);
    }
}
