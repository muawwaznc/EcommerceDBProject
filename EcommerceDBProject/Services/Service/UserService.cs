using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using EcommerceDBProject.Enum;

namespace EcommerceDBProject.Services.Service
{
    public class UserService : IUserInterface
    {
        public UserDetail IsAuthenicated(string email, string password)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var userDetail = db.UserDetails.FirstOrDefault(x => x.Email == email);
                if (userDetail != null)
                {
                    var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetail.UserDetailId);
                    if (seller != null && seller.Password == password)
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
    
        public UserDetail SignUp(SignUpModel signUpModel)
        {
            try
            {
                using (var db = new EcommerceDbprojectContext())
                {
                    var address = signUpModel.Address;
                    if (IsAddressCorrect(address))
                    {
                        db.Addresses.Add(address);
                        db.SaveChanges();
                    }
                    var userDetail = new UserDetail
                    {
                        AddressId = address.AddressId,
                        Email = signUpModel.Email,
                        PhoneNumber = signUpModel.PhoneNumber,
                        Picture = "DefaultPicture"
                    };
                    db.UserDetails.Add(userDetail);
                    db.SaveChanges();
                    if (signUpModel.UserRole == "seller")
                    {
                        var seller = new Seller
                        {
                            UserDetailId = userDetail.UserDetailId,
                            FirstName = signUpModel.FirstName,
                            LastName = signUpModel.LastName,
                            RegistrationDate = DateTime.Now,
                            Password = signUpModel.Password
                        };
                        db.Sellers.Add(seller);
                        db.SaveChanges();
                    }
                    else if (signUpModel.UserRole == "customer")
                    {
                        var customer = new Customer
                        {
                            UserDetailId = userDetail.UserDetailId,
                            FirstName = signUpModel.FirstName,
                            LastName = signUpModel.LastName,
                            RegistrationDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,
                            DateOfBirth = signUpModel.DateOfBirth,
                            Password = signUpModel.Password
                        };
                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    return userDetail;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool IsAddressCorrect(Address address)
        {
            if(address.HouseNumber == null || address.Street == null ||
               address.City == null || address.Country == null ||
               address.Region == null || address.ZipCode == null)
            {
                return false;
            }
            return true;
        }

        public UserRole GetUserRoleByUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                if (seller == null)
                {
                    var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                    if (customer != null)
                    {
                        return UserRole.Customer;
                    }
                    return UserRole.UserNotFound;
                }
                return UserRole.Seller;
            }
        }

        public Customer GetCustomerFromUserDetailId(string userDetailId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                return customer;
            }
        }

        public Address GetAddressByUserDetailId(string userDetailId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var addressId = db.UserDetails.FirstOrDefault(x => x.UserDetailId == userDetailId).AddressId;
                if(addressId != null)
                {
                    var address = db.Addresses.FirstOrDefault(x => x.AddressId == addressId);
                    return address;
                }
                return null;
            }
        }

        public Seller GetSellerFromSellerId(string sellerId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller;
            }
        }

        public string GetSellerFullNameFromSellerId(string sellerId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller.LastName + ", " + seller.FirstName;
            }
        }

        public Seller GetSellerFromUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                return seller;
            }
        }
    }
}
