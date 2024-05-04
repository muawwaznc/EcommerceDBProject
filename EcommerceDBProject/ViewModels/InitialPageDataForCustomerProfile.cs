using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerProfile
    {
        public UserDetail UserDetail { get; set; } = new();
        public CustomerViewModel Customer { get; set; } = new();
        public AddressViewModel Address { get; set; } = new();
    }

    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Password { get; set; }
    }
}
