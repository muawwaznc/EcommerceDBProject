using EcommerceDBProject.NewF;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class CommonService : ICommonInterface
    {
        private IInventoryItemInterface _inventoryItemService;
        private IProductInterface _productService;
        private IUserInterface _userService;

        public CommonService(IInventoryItemInterface inventoryItemService,
            IProductInterface productService, IUserInterface userService)
        {
            _inventoryItemService = inventoryItemService;
            _productService = productService;
            _userService = userService;
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
    }
}
