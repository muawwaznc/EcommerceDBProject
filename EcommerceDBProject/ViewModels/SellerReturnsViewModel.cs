namespace EcommerceDBProject.ViewModels
{
    public class SellerReturnsViewModel
    {
        public string OrderItemId { get; set; }
        public string CustomerName { get; set; }
        public string InventoryItemName { get; set; }
        public string ReturnReason { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnStatus { get; set; }

    }
}
