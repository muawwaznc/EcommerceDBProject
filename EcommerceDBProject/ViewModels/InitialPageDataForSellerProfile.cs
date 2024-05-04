using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerProfile
    {
        public UserDetail UserDetail { get; set; } = new();
        public SellerViewModel Seller { get; set; } = new();
        public AddressViewModel Address { get; set; } = new();
    }

    public class SellerViewModel 
    { 
        public string SellerId { get; set; }
        public string UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SellerRating { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Password { get; set; }
    }

    public class AddressViewModel
    {
        public string AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; } 
        public string ZipCode { get; set; }
    }
}
