namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerReviews
    {
        public string CustomerId { get; set; }
        public List<CustomerReviewsViewModel> CustomerReviewsViewModel { get; set; }
    }

    public class CustomerReviewsViewModel
    {
        public string ReviewId { get; set; }
        public string OrderId { get; set; }
        public string InventoryItemName { get; set; }
        public string SellerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ReviewStars { get; set; }
        public string ReviewText { get; set; }
    }
}
