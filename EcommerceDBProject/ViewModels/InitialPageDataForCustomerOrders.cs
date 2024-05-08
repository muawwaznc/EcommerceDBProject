using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerOrders
    {
        public List<CustomerOrdersViewModel> CustomerOrdersViewModelList { get; set; } = new();
        public bool ShowReviewDialogBox { get; set; } = false;
        public bool ShowReturnDialogBox { get; set; } = false;
        public ProductReturn ProductReturn { get; set; } = new ();
        public ProductReview ProductReview { get; set; } = new();
        public int OrderQuantityForReturn { get; set; }
    }

    public class CustomerOrdersViewModel 
    {
        public string OrderId { get; set; }
        public string OrderItemId { get; set; }
        public string InventoryItemName { get; set; }
        public int OrderQuantity { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsReviewButtonDisabled { get; set; } = true;
        public bool IsReturnButtonDisabled { get; set; } = true;
    }



}
