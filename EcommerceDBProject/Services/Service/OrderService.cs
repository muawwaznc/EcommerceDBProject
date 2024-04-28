using EcommerceDBProject.NewF;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class OrderService: IOrderInterface
    {
        IUserInterface _userService;
        public OrderService(IUserInterface userService)
        {
            _userService = userService;
        }

        public void PlaceOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList, CustomerDetailViewModel customerDetail)
        {
            var shippingAddress = AddShippingAddress(customerDetail.ShippingAddress);
            var order = new Order
            {
                CustomerId = _userService.GetCustomerFromUserDetailId(customerDetail.UserDetailId).CustomerId,
                OrderDate = DateTime.Now,
                RequiredShippingDate = DateTime.Now.AddDays(7),
                TotalPrice = CalculateTotalPriceForOrder(buyInventoryItemViewModelList),
                ShippingAddressId = shippingAddress.AddressId,
                PaymentMethod = customerDetail.PaymentMethod,
                ShippingMethod = customerDetail.ShippingMethod
            };
            order = AddOrder(order);
            foreach (var buyInventoryItemViewModel in buyInventoryItemViewModelList)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    InventoryItemId = buyInventoryItemViewModel.InventoryItem.InventoryItemId,
                    Quantity = buyInventoryItemViewModel.QuantityToBuy,
                    UnitPrice = buyInventoryItemViewModel.InventoryItem.SalePrice,//minus the promotion percentage in future
                    IsReturned = false,
                    OrderStatus = "Processing",
                };
                AddOrderItem(orderItem);
            }
        }

        private double CalculateTotalPriceForOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList)
        {
            double totalPrice = 0;
            foreach(var buyInventoryItemViewModel in buyInventoryItemViewModelList)
            {
                totalPrice += buyInventoryItemViewModel.QuantityToBuy * buyInventoryItemViewModel.InventoryItem.SalePrice;
            }
            return totalPrice;
        }

        private Address AddShippingAddress(Address address)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return address;
            }
        }

        private Order AddOrder(Order order)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }

        private void AddOrderItem(OrderItem orderItem)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
            }
        }
    }
}
