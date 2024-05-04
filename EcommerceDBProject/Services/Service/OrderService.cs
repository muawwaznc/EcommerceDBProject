using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class OrderService: IOrderInterface
    {
        IUserInterface _userService;
        IProductInterface _productService;
        IInventoryItemInterface _inventoryItemService;
        IOrderReturnReviewInterface _orderReturnReviewService;
        public OrderService(IUserInterface userService, IProductInterface productService,
            IInventoryItemInterface inventoryItemService,
            IOrderReturnReviewInterface orderReturnReviewService)
        {
            _userService = userService;
            _productService = productService;
            _inventoryItemService = inventoryItemService;
            _orderReturnReviewService = orderReturnReviewService;
        }

        public void PlaceOrder(List<BuyInventoryItemViewModel> buyInventoryItemViewModelList, CustomerDetailViewModel customerDetail)
        {
            var shippingAddress = AddShippingAddress(customerDetail.ShippingAddress);
            var order = new Order
            {
                CustomerId = _userService.GetCustomerFromUserDetailId(customerDetail.UserDetailId).CustomerId,
                OrderDate = DateTime.Now,
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
                    RequiredShippingDate = DateTime.Now.AddDays(7),
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
                if (address.AddressId != null)
                {
                    var dbAddress = db.Addresses.FirstOrDefault(x => x.AddressId == address.AddressId);
                    bool isDifferent = false;
                    if(dbAddress.HouseNumber != address.HouseNumber ||
                        dbAddress.Street != address.Street ||
                        dbAddress.City != address.City ||
                        dbAddress.Country != address.Country ||
                        dbAddress.Region != address.Region ||
                        dbAddress.ZipCode != address.ZipCode)
                    {
                        isDifferent = true;
                    }
                    else
                    {
                        return address;
                    }
                    
                }
                var newAddress = new Address
                {
                    HouseNumber = address.HouseNumber,
                    Street = address.Street,
                    City = address.City,
                    Country = address.Country,
                    Region = address.Region,
                    ZipCode = address.ZipCode
                };
                db.Addresses.Add(newAddress);
                db.SaveChanges();
                return newAddress;
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

        public List<CustomerOrdersViewModel> GetCustomerOrdersViewModelList(string userDetailId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var customersOrdersList = db.Orders.Where(x => x.CustomerId == customer.CustomerId).ToList();
                var orderItemsList = new List<OrderItem>();
                foreach(var order in customersOrdersList)
                {
                    var orderItemsOfOrder = db.OrderItems.Where(x => x.OrderId == order.OrderId).ToList();
                    orderItemsList.AddRange(orderItemsOfOrder);
                }
                var customerOrdersViewModelList = new List<CustomerOrdersViewModel>();
                foreach (var orderItem in orderItemsList)
                {
                    var customerOrdersViewModel = new CustomerOrdersViewModel
                    {
                        OrderId = orderItem.OrderId,
                        InventoryItemName = _productService.GetProductFromInventoryItemId(orderItem.InventoryItemId).ProductName,
                        OrderQuantity = orderItem.Quantity,
                        TotalPrice = orderItem.Quantity * _inventoryItemService.GetInventoryItemFromInventoryItemId(orderItem.InventoryItemId).SalePrice,
                        OrderStatus = orderItem.OrderStatus,
                        OrderDate = customersOrdersList.FirstOrDefault(x => x.OrderId == orderItem.OrderId).OrderDate,
                    };
                    if(orderItem.ShippingDate != null)
                    {
                        if (!orderItem.IsReturned)
                        {
                            customerOrdersViewModel.IsReturnButtonDisabled = false;
                        }
                        if (_orderReturnReviewService.IsReviewAvailable(orderItem.OrderItemId))
                        {
                            customerOrdersViewModel.IsReviewButtonDisabled = false;
                        }                        
                    }
                    customerOrdersViewModelList.Add(customerOrdersViewModel);
                }
                return customerOrdersViewModelList;
            }
        }
    
        public List<Order> GetOrdersListFromCustomerId(string customerId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var orders = db.Orders.Where(x => x.CustomerId == customerId).ToList();
                return orders;
            }
        }

        public List<OrderItem> GetOrderItemsListFromOrderId(string orderId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var orderItems = db.OrderItems.Where(x => x.OrderId == orderId).ToList();
                return orderItems;
            }
        }

        public List<SellerOrdersViewModel> GetSellerOrdersViewModelList(string userDetailId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var sellerInventoryItems = _inventoryItemService.GetSellerInventoryItemsListFromSellerId(seller.SellerId);
                var sellerOrdersViewModelList = new List<SellerOrdersViewModel>();
                foreach (var invenoryItem in sellerInventoryItems)
                {
                    var orderItemsList = db.OrderItems.Where(x => x.InventoryItemId == invenoryItem.InventoryItemId).ToList();
                    foreach(var orderItem in orderItemsList)
                    {
                        var order = db.Orders.FirstOrDefault(x => x.OrderId == orderItem.OrderId);
                        var customer = _userService.GetCustomerFromCustomerId(order.CustomerId);
                        sellerOrdersViewModelList.Add(new SellerOrdersViewModel
                        {
                            OrderId = order.OrderId,
                            OrderItemId = orderItem.OrderItemId,
                            CustomerName = customer.LastName + ", " + customer.FirstName,
                            InventoryItemName = _productService.GetProductFromInventoryItemId(orderItem.InventoryItemId).ProductName,
                            OrderQuantity = orderItem.Quantity,
                            TotalPrice = orderItem.Quantity * _inventoryItemService.GetInventoryItemFromInventoryItemId(orderItem.InventoryItemId).SalePrice,
                            OrderStatus = orderItem.OrderStatus,
                            OrderDate = order.OrderDate,
                            IsCompleteOrderButtonDisabled = orderItem.ShippingDate != null
                        });
                    }
                }
                return sellerOrdersViewModelList;
            }
        }
        
        public void ShipOrder(string orderItemId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var orderItem = db.OrderItems.FirstOrDefault(x => x.OrderItemId == orderItemId);
                orderItem.ShippingDate = DateTime.Now;
                orderItem.OrderStatus = "Completed";
                db.OrderItems.Update(orderItem);
                db.SaveChanges();
            }
        }
    }
}
