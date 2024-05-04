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
            using (var db = new EcommerceDbContext())
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
                using (var db = new EcommerceDbContext())
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
            using (var db = new EcommerceDbContext())
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
            using(var db = new EcommerceDbContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                return customer;
            }
        }

        public Address GetAddressByUserDetailId(string userDetailId)
        {
            using(var db = new EcommerceDbContext())
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
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller;
            }
        }

        public string GetSellerFullNameFromSellerId(string sellerId)
        {
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller.LastName + ", " + seller.FirstName;
            }
        }

        public Seller GetSellerFromUserDetailId(string userDetailId)
        {
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.UserDetailId == userDetailId);
                return seller;
            }
        }

        public Customer GetCustomerFromCustomerId(string customerId)
        {
            using (var db = new EcommerceDbContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.CustomerId == customerId);
                return customer;
            }
        }

        public UserDetail GetUserDetailFromUserDetailId(string userDetailId)
        {
            using(var db = new EcommerceDbContext())
            {
                var userDetail = db.UserDetails.FirstOrDefault(x => x.UserDetailId == userDetailId);
                return userDetail;
            }
        }

        public void UpdateSellerDetails(InitialPageDataForSellerProfile sellerData)
        {
            using (var db = new EcommerceDbContext())
            {
                var existingSeller = db.Sellers.FirstOrDefault(s => s.SellerId == sellerData.Seller.SellerId);
                if (existingSeller != null)
                {
                    existingSeller.FirstName = sellerData.Seller.FirstName;
                    existingSeller.LastName = sellerData.Seller.LastName;
                    existingSeller.SellerRating = sellerData.Seller.SellerRating;
                    existingSeller.RegistrationDate = sellerData.Seller.RegistrationDate;
                    existingSeller.Password = sellerData.Seller.Password;

                    db.Sellers.Update(existingSeller);
                }

                var existingAddress = db.Addresses.FirstOrDefault(a => a.AddressId == sellerData.Address.AddressId);
                if (existingAddress != null)
                {
                    existingAddress.HouseNumber = sellerData.Address.HouseNumber;
                    existingAddress.Street = sellerData.Address.Street;
                    existingAddress.City = sellerData.Address.City;
                    existingAddress.Country = sellerData.Address.Country;
                    existingAddress.Region = sellerData.Address.Region;
                    existingAddress.ZipCode = sellerData.Address.ZipCode;

                    db.Addresses.Update(existingAddress);
                }

                db.SaveChanges();
            }
        }

        public void UpdateCustomerDetails(InitialPageDataForCustomerProfile customerData)
        {
            using (var db = new EcommerceDbContext())
            {
                var existingCustomer = db.Customers.FirstOrDefault(s => s.CustomerId == customerData.Customer.CustomerId);
                if (existingCustomer != null)
                {
                    existingCustomer.FirstName = customerData.Customer.FirstName;
                    existingCustomer.LastName = customerData.Customer.LastName;
                    existingCustomer.DateOfBirth = customerData.Customer.DateOfBirth;
                    existingCustomer.RegistrationDate = customerData.Customer.RegistrationDate;
                    existingCustomer.LastLoginDate = customerData.Customer.LastLoginDate;
                    existingCustomer.Password = customerData.Customer.Password;

                    db.Customers.Update(existingCustomer);
                }

                var existingAddress = db.Addresses.FirstOrDefault(a => a.AddressId == customerData.Address.AddressId);
                if (existingAddress != null)
                {
                    existingAddress.HouseNumber = customerData.Address.HouseNumber;
                    existingAddress.Street = customerData.Address.Street;
                    existingAddress.City = customerData.Address.City;
                    existingAddress.Country = customerData.Address.Country;
                    existingAddress.Region = customerData.Address.Region;
                    existingAddress.ZipCode = customerData.Address.ZipCode;

                    db.Addresses.Update(existingAddress);
                }

                db.SaveChanges();
            }
        }

        public void AddSupplier(InitialPageDataForAddSupplier supplierViewModel)
        {
            try
            {
                using (var db = new EcommerceDbContext())
                {
                    var address = supplierViewModel.SupplierAddress;
                    if (IsAddressCorrect(address))
                    {
                        db.Addresses.Add(address);
                        db.SaveChanges();
                    }
                    var userDetail = new UserDetail
                    {
                        AddressId = address.AddressId,
                        Email = supplierViewModel.SupplierDetails.Email,
                        PhoneNumber = supplierViewModel.SupplierDetails.PhoneNumber,
                        Picture = "DefaultPicture"
                    };
                    db.UserDetails.Add(userDetail);
                    db.SaveChanges();
                    var supplier = new Supplier
                    {
                        UserDetailId = userDetail.UserDetailId,
                        SupplierName = supplierViewModel.Supplier.SupplierName,
                        ContactPersonName = supplierViewModel.Supplier.ContactPersonName
                    };
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                
            }
        }

    }
}
