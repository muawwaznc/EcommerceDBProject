using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class CommonService : ICommonInterface
    {
        private IInventoryItemInterface _inventoryItemService;
        private IProductInterface _productService;

        public CommonService(IInventoryItemInterface inventoryItemService,
            IProductInterface productService)
        {
            _inventoryItemService = inventoryItemService;
            _productService = productService;
        }

        public InitialPageDataForCustomerDashboard GetInitialPageDataForCustomerDashboard()
        {
            InitialPageDataForCustomerDashboard initialPageData = new InitialPageDataForCustomerDashboard
            {
                AllInventoryItems = _inventoryItemService.GetAllInventoryItemsList(),
                SelectedCetagory = "",
                ProductCategories = _productService.GetAllProductCategories()
            };
            return initialPageData;
        }
    }
}
