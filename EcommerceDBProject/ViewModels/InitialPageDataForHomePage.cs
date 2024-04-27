namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForHomePage
    {
        public SignInModel? SignInModel { get; set; } = new();
        public SignUpModel? SignUpModel { get; set; } = new();
    }

    public class SignInModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class SignUpModel
    {
        public string? FirstName { get;set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? UserRole { get; set; }
        public AddressModel? Address { get; set; } = new();
    }

    public class AddressModel
    {
        public string? HouseNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }

    }
}
