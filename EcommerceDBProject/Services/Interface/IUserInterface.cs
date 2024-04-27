using EcommerceDBProject.NewF;

namespace EcommerceDBProject.Services.Interface
{
    public interface IUserInterface
    {
        UserDetail IsAuthenicated(string email, string password);
    }
}
