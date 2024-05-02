using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using System.Runtime.CompilerServices;

namespace EcommerceDBProject.Services.Service
{
    public class CommonService : ICommonInterface
    {
        private IInventoryItemInterface _inventoryItemService;
        private IProductInterface _productService;
        private IUserInterface _userService;
        private IOrderInterface _orderService;
        private IOrderReturnReviewInterface _orderReturnReviewService;
        private IPromotionInterface _promotionService;

        public CommonService(IInventoryItemInterface inventoryItemService,
            IProductInterface productService, IUserInterface userService,
            IOrderInterface orderService, IOrderReturnReviewInterface orderReturnReviewService)
        {
            _inventoryItemService = inventoryItemService;
            _productService = productService;
            _userService = userService;
            _orderService = orderService;
            _orderReturnReviewService = orderReturnReviewService;
        }

        public InitialPageDataForCustomerDashboard GetInitialPageDataForCustomerDashboard(string userDetailId)
        {
            var shippingAddress = _userService.GetAddressByUserDetailId(userDetailId);
            if(shippingAddress == null)
            {
                shippingAddress = new Address();
            }
            InitialPageDataForCustomerDashboard initialPageData = new InitialPageDataForCustomerDashboard
            {
                AllInventoryItems = _inventoryItemService.GetAllInventoryItemsList(),
                ProductCategories = _productService.GetAllProductCategories(),
                CustomerDetailViewModel = new CustomerDetailViewModel
                {
                    UserDetailId = userDetailId,
                    ShippingAddress = shippingAddress,
                    ShippingMethod = "Express",
                    PaymentMethod = "Cash On Delivery"
                }
            };
            return initialPageData;
        }

        public InitialPageDataForCustomerOrders GetInitialPageDataForCustomerOrders(string userDetailId)
        {
            var initialPageData = new InitialPageDataForCustomerOrders
            {
                CustomerOrdersViewModelList = _orderService.GetCustomerOrdersViewModelList(userDetailId)
            };
            return initialPageData;
        }

        public InitialPageDataForCustomerReturns GetInitialPageDataForCustomerReturns(string userDetailId)
        {
            var initialPageData = new InitialPageDataForCustomerReturns
            {
                CustomerReturnsViewModel = _orderReturnReviewService.GetCustomerReturnsViewModelListFromUserDetailId(userDetailId)
            };
            return initialPageData;
        }

        public InitialPageDataForCustomerReviews GetInitialPageDataForCustomerReviews(string userDetailId)
        {
            var initialPageData = new InitialPageDataForCustomerReviews
            {
                CustomerId = _userService.GetCustomerFromUserDetailId(userDetailId).CustomerId,
                CustomerReviewsViewModel = _orderReturnReviewService.GetCustomerReviewsViewModelListFromUserDetailId(userDetailId)

            };
            return initialPageData;
        }

        public InitialPageDataForSellerInventoryItems GetInitialPageDataForSellerInventoryItems(string userDetailId)
        {
            var seller = _userService.GetSellerFromUserDetailId(userDetailId);
            var initialPageData = new InitialPageDataForSellerInventoryItems
            {
                Seller = seller,
                SellerInventoryItems = _inventoryItemService.GetSellerInventoryItemsListFromSellerId(seller.SellerId),
                ProductCategories = _productService.GetAllProductCategories()
            };
            return initialPageData;
        }

        public InitialPageDataForSellerOrders GetInitialPageDataForSellerOrders(string userDetailId)
        {
            var initialPageData = new InitialPageDataForSellerOrders 
            {
                SellerOrdersViewModelList = _orderService.GetSellerOrdersViewModelList(userDetailId)
            };
            return initialPageData;
        }

        public InitialPageDataForSellerDashboard GetInitialPageDataForSellerDashboard(string userDetailId)
        {
            var address = _userService.GetAddressByUserDetailId(userDetailId);
            var seller = _userService.GetSellerFromUserDetailId(userDetailId);
            var userDetail = _userService.GetUserDetailFromUserDetailId(userDetailId);
            var initialPageData = new InitialPageDataForSellerDashboard
            {
                SellerName = _userService.GetSellerFullNameFromSellerId(seller.SellerId),
                Email = userDetail.Email,
                PhoneNumber = userDetail.PhoneNumber,
                City = address.City,
                Country = address.Country,
                RegistrationDate = seller.RegistrationDate.Value.Date,
                SellerRating = seller.SellerRating
            };
            return initialPageData;
        }

        public InitialPageDataForSellerProfile GetInitialPageDataForSellerProfile(string userDetailId)
        {
            var address = _userService.GetAddressByUserDetailId(userDetailId);
            var seller = _userService.GetSellerFromUserDetailId(userDetailId);
            var userDetail = _userService.GetUserDetailFromUserDetailId(userDetailId);
            var initialPageData = new InitialPageDataForSellerProfile
            {
                Seller = new SellerViewModel
                {
                    SellerId = seller.SellerId,
                    UserDetailId = seller.UserDetailId,
                    FirstName = seller.FirstName,
                    LastName = seller.LastName,
                    SellerRating = seller.SellerRating,
                    RegistrationDate = seller.RegistrationDate,
                    Password = seller.Password
                },
                UserDetail = userDetail,
                Address = new AddressViewModel
                {
                    AddressId = address.AddressId,
                    HouseNumber = address.HouseNumber,
                    Street = address.Street,
                    City = address.City,
                    Country = address.Country,
                    Region = address.Region,
                    ZipCode = address.ZipCode
                }
            };
            return initialPageData;
        }

        public InitialPageDataForCustomerProfile GetInitialPageDataForCustomerProfile(string userDetailId)
        {
            var address = _userService.GetAddressByUserDetailId(userDetailId);
            var customer = _userService.GetCustomerFromUserDetailId(userDetailId);
            var userDetail = _userService.GetUserDetailFromUserDetailId(userDetailId);
            var initialPageData = new InitialPageDataForCustomerProfile
            {
                Customer = new CustomerViewModel
                {
                    CustomerId = customer.CustomerId,
                    UserDetailId = customer.UserDetailId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    RegistrationDate = customer.RegistrationDate,
                    LastLoginDate = customer.LastLoginDate,
                    Password = customer.Password
                },
                UserDetail = userDetail,
                Address = new AddressViewModel
                {
                    AddressId = address.AddressId,
                    HouseNumber = address.HouseNumber,
                    Street = address.Street,
                    City = address.City,
                    Country = address.Country,
                    Region = address.Region,
                    ZipCode = address.ZipCode
                }
            };
            return initialPageData;
        }
        
        public InitialPageDataForAddProduct GetInitialPageDataForAddProduct()
        {
            var initialPageDate = new InitialPageDataForAddProduct
            {
                ProductCategoriesList = _productService.GetAllProductCategories(),
                SuppliersList = _productService.GetAllSuppliers()
            };
            return initialPageDate;
        }

        public InitialPageDataForSellerPromotion GetInitialPageDataForSellerPromotion(string userDetailId)
        {
            var seller = _userService.GetSellerFromUserDetailId(userDetailId);
            var initialPageData = new InitialPageDataForSellerPromotion();
            initialPageData.SellerId = seller.SellerId;
            //initialPageData.PromotionList = _promotionService.GetAllPromotionList();
            initialPageData.productCategoriesList = _productService.GetAllProductCategories();
            initialPageData.inventoryItemsList = _inventoryItemService.GetSellerInventoryItemsListFromSellerId(seller.SellerId);
            return initialPageData;
        }

        public InitialPageDataForUpdateDeleteProduct GetInitialPageDataForUpdateDeleteProduct()
        {
            var products = _productService.GetAllProducts();
            var productsList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsList.Add(new ProductViewModel
                {
                    Product = product,
                    Category = _productService.GetProductCategoryByCategoryId(product.CategoryId),
                    Supplier = product.SupplierId != null ? _productService.GetSupplierBySupplierId(product.SupplierId) : null
                });
            }
            var initialPageData = new InitialPageDataForUpdateDeleteProduct {
                Products = productsList,
                CategoriesList = _productService.GetAllProductCategories(),
                SuppliersList = _productService.GetAllSuppliers()
            };
            return initialPageData;
        }
    }
}
