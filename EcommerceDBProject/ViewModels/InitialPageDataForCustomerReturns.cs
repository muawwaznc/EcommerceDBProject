using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerReturns
    {
        public List<CustomerReturnsViewModel> CustomerReturnsViewModel { get; set; }
    }

    public class CustomerReturnsViewModel
    {
        public string ReturnId { get; set; }
        public string OrderId { get; set; }
        public string InventoryItemName { get; set; }
        public string SellerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnStatus { get; set; }
        public string ReturnReason { get; set; }
    }
}
