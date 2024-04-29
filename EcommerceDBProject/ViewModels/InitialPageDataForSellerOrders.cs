namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerOrders
    {
        public List<SellerOrdersViewModel> SellerOrdersViewModelList { get; set; }
    }

    public class SellerOrdersViewModel 
    {
        public string OrderId { get; set; }
        public string OrderItemId { get; set; }
        public string CustomerName { get; set; }
        public string InventoryItemName { get; set; }
        public int OrderQuantity { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsCompleteOrderButtonDisabled { get; set; } = false;
    }

}
