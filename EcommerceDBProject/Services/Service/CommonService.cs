﻿using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class CommonService : ICommonInterface
    {
        private IInventoryItemInterface _inventoryItemService;
        private IProductInterface _productService;
        private IUserInterface _userService;
        private IOrderInterface _orderService;
        private IOrderReturnReviewInterface _orderReturnReviewService;

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
    }
}
