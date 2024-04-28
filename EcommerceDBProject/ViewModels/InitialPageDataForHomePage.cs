using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForHomePage
    {
        public SignInModel? SignInModel { get; set; } = new();
        public SignUpModel? SignUpModel { get; set; } = new();
        public bool IsLoading { get; set; } = false;
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
        public DateOnly DateOfBirth { get; set; }
        public Address? Address { get; set; } = new();
    }
}
