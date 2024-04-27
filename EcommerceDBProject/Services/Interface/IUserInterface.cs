using EcommerceDBProject.Enum;
using EcommerceDBProject.NewF;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IUserInterface
    {
        UserDetail IsAuthenicated(string email, string password);
        UserDetail SignUp(SignUpModel signUpModel);
        UserRole GetUserRoleByUserDetailId(string userDetailId);
    }
}
