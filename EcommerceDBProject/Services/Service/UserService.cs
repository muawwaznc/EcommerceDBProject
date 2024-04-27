using EcommerceDBProject.NewF;
using EcommerceDBProject.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDBProject.Services.Service
{
    public class UserService : IUserInterface
    {
        public UserDetail IsAuthenicated(string email, string password)
        {
            var db = new EcommerceDbprojectContext();
            var userDetail = db.UserDetails.FirstOrDefault(x => x.Email == email);
            if(userDetail != null)
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetail.UserDetailId);
                if(seller != null && seller.Password == password)
                {
                    return userDetail;
                }
                else
                {
                    var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetail.UserDetailId);
                    if (customer != null && customer.Password == password)
                    {
                        return userDetail;
                    }
                }
            }
            return null;
        }
    }
}
