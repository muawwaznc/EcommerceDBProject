using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class OrderReturnReviewService : IOrderReturnReviewInterface
    {
        IProductInterface _productService;
        IUserInterface _userService;
        public OrderReturnReviewService(IProductInterface productService, IUserInterface userService)
        {
            _productService = productService;
            _userService = userService;
        }
        public bool IsReturnAvailable(string orderItemId)
        {
            using (var db = new EcommerceDbContext())
            {
                var produtReturn = db.ProductReturns.FirstOrDefault(x => x.OrderItemId == orderItemId);
                if (produtReturn != null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsReviewAvailable(string orderItemId)
        {
            using (var db = new EcommerceDbContext())
            {
                var produtReview = db.ProductReviews.FirstOrDefault(x => x.OrderItemId == orderItemId);
                if (produtReview != null)
                {
                    return false;
                }
                return true;
            }
        }
        public void AddReturn(ProductReturn productReturn)
        {
            using (var db = new EcommerceDbContext())
            {
                db.ProductReturns.Add(productReturn);
                db.SaveChanges();
            }
        }

        public void UpdateProductReturn(string returnId)
        {
            using (var db = new EcommerceDbContext())
            {
                var productReturn = db.ProductReturns.FirstOrDefault(x => x.ReturnId == returnId);
                productReturn.ReturnStatus = "Returned";
                db.ProductReturns.Update(productReturn);
                db.SaveChanges();
            }
        }

        public void RejectReturnRequest(string returnId)
        {
            using(var db = new EcommerceDbContext())
            {
                var productReturn = db.ProductReturns.FirstOrDefault(x => x.ReturnId == returnId);
                var orderItem = db.OrderItems.FirstOrDefault(x => x.OrderItemId == productReturn.OrderItemId);
                orderItem.IsReturned = false;
                UpdateOrderItem(orderItem);
                DeleteReturnRequest(productReturn);
            }
        }

        private void DeleteReturnRequest(ProductReturn productReturn)
        {
            using(var db = new EcommerceDbContext())
            {
                db.ProductReturns.Remove(productReturn);
                db.SaveChanges();
            }
        }

        private void UpdateOrderItem(OrderItem orderItem)
        {
            using(var db = new EcommerceDbContext())
            {
                db.OrderItems.Update(orderItem);
                db.SaveChanges();
            }
        }
        
        public void AddReview(ProductReview productReview)
        {
            using (var db = new EcommerceDbContext())
            {
                db.ProductReviews.Add(productReview);
                db.SaveChanges();
            }
        }
        
        public List<SellerReturnsViewModel> GetSellerReturns(string userDetailId)
        {
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var sellerInventoryItemsList = db.InventoryItems.Where(x => x.SellerId == seller.SellerId).ToList();
                List<SellerReturnsViewModel> sellerReturnList = new();
                foreach (var inventoryItem in sellerInventoryItemsList)
                {
                    var returnOrderItemsList = db.OrderItems.Where(x => x.InventoryItemId == inventoryItem.InventoryItemId && x.IsReturned == true).ToList();
                    foreach (var orderItem in returnOrderItemsList)
                    {
                        var order = db.Orders.FirstOrDefault(x => x.OrderId == orderItem.OrderId);
                        var customer = _userService.GetCustomerFromCustomerId(order.CustomerId);
                        var product = _productService.GetProductFromInventoryItemId(inventoryItem.InventoryItemId);
                        var productReturn = db.ProductReturns.FirstOrDefault(x => x.OrderItemId == orderItem.OrderItemId);
                        var sellerReturnsViewModel = new SellerReturnsViewModel
                        {
                            ReturnId = productReturn.ReturnId,
                            OrderItemId = orderItem.OrderItemId,
                            CustomerName = customer.FirstName + " " + customer.LastName,
                            InventoryItemName = product.ProductName,
                            ReturnReason = productReturn.ReturnReason,
                            ReturnDate = productReturn.ReturnDate,
                            ReturnStatus = productReturn.ReturnStatus,
                        };
                        if (sellerReturnsViewModel.ReturnStatus == "Rejected" || sellerReturnsViewModel.ReturnStatus == "Returned")
                        {
                            sellerReturnsViewModel.IsButtonDisabled = true;
                        }
                        sellerReturnList.Add(sellerReturnsViewModel);
                    }
                }
                return sellerReturnList;
            }

        }
        
        public List<CustomerReviewsViewModel> GetCustomerReviewsViewModelListFromUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var customersOrders = db.Orders.Where(x => x.CustomerId == customer.CustomerId).ToList();
                List<CustomerReviewsViewModel> customerReviewsViewModelList = new List<CustomerReviewsViewModel>();
                foreach (var order in customersOrders)
                {
                    var orderItemsList = db.OrderItems.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var orderItem in orderItemsList)
                    {
                        var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == orderItem.InventoryItemId);
                        var seller = _userService.GetSellerFromSellerId(inventoryItem.SellerId);
                        var review = db.ProductReviews.FirstOrDefault(x => x.OrderItemId == orderItem.OrderItemId);
                        if (review != null)
                        {
                            customerReviewsViewModelList.Add(new CustomerReviewsViewModel
                            {
                                ReviewId = review.ReviewId,
                                OrderId = order.OrderId,
                                InventoryItemName = _productService.GetProductFromInventoryItemId(orderItem.InventoryItemId).ProductName,
                                SellerName = seller.LastName + ", " + seller.FirstName,
                                OrderDate = order.OrderDate,
                                ReviewStars = review.Rating,
                                ReviewText = review.ReviewText
                            });
                        }
                    }
                }
                return customerReviewsViewModelList;
            }
        }

        public List<CustomerReturnsViewModel> GetCustomerReturnsViewModelListFromUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var customersOrders = db.Orders.Where(x => x.CustomerId == customer.CustomerId).ToList();
                List<CustomerReturnsViewModel> customerReturnsViewModelList = new List<CustomerReturnsViewModel>();

                foreach (var order in customersOrders)
                {
                    var orderItemsList = db.OrderItems.Where(x => x.OrderId == order.OrderId).ToList();
                    foreach (var orderItem in orderItemsList)
                    {
                        var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == orderItem.InventoryItemId);
                        var seller = _userService.GetSellerFromSellerId(inventoryItem.SellerId);
                        var returns = db.ProductReturns.FirstOrDefault(x => x.OrderItemId == orderItem.OrderItemId);
                        if (returns != null)
                        {
                            customerReturnsViewModelList.Add(new CustomerReturnsViewModel
                            {
                                ReturnId = returns.ReturnId,
                                OrderId = order.OrderId,
                                InventoryItemName = _productService.GetProductFromInventoryItemId(orderItem.InventoryItemId).ProductName,
                                SellerName = seller.LastName + ", " + seller.FirstName,
                                OrderDate = order.OrderDate,
                                ReturnDate = returns.ReturnDate,
                                ReturnStatus = returns.ReturnStatus,
                                ReturnReason = returns.ReturnReason ?? "-"
                            });
                        }
                    }
                }
                return customerReturnsViewModelList;
            }
        }
    }
}
