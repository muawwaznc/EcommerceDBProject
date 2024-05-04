using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.NewDatabase;
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
            using (var db = new EcommerceDbprojectContext())
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
            using (var db = new EcommerceDbprojectContext())
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
            using (var db = new EcommerceDbprojectContext())
            {
                db.ProductReturns.Add(productReturn);
                db.SaveChanges();
            }
        }
        public void AddReview(ProductReview productReview)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                db.ProductReviews.Add(productReview);
                db.SaveChanges();
            }
        }
        public List<SellerReturnsViewModel> GetSellerReturns(string userDetailId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                var allSellerProduct = db.InventoryItems.Where(x => x.SellerId == seller.SellerId).ToList();
                List<SellerReturnsViewModel> sellerReturnList = new();
                foreach(var inventoryItem in allSellerProduct)
                {
                    var OnlyReturnOrder = db.OrderItems.Where(x => x.InventoryItemId == inventoryItem.InventoryItemId && x.IsReturned == true).FirstOrDefault();
                    var customerId = db.Orders.Where(x => x.OrderId == OnlyReturnOrder.OrderId).Select(x => x.CustomerId).FirstOrDefault();
                    var customerName = db.Customers.Where(x => x.CustomerId == customerId).Select(x => x.FirstName +" "+ x.LastName).FirstOrDefault();
                    var productName = db.Products.Where(x => x.ProductId == inventoryItem.ProductId).Select(x => x.ProductName).FirstOrDefault();
                    var returnProduct = db.ProductReturns.Where(x => x.OrderItemId == OnlyReturnOrder.OrderItemId).FirstOrDefault();
                    if(returnProduct != null)
                    {
                        sellerReturnList.Add(new SellerReturnsViewModel
                        {
                            CustomerName = customerName,
                            InventoryItemName = productName,
                            ReturnDate = returnProduct.ReturnDate,
                            ReturnReason = returnProduct.ReturnReason,
                            ReturnStatus = returnProduct.ReturnStatus,
                        });
                    }

                }
                return sellerReturnList;
            }

        }
        public List<CustomerReviewsViewModel> GetCustomerReviewsViewModelListFromUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbprojectContext())
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
            using (var db = new EcommerceDbprojectContext())
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
