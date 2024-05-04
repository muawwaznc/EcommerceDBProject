using EcommerceDBProject.NewDatabase;
using EcommerceDBProject.Services.Interface;
using IronXL;
using Microsoft.Data.SqlClient;
using Syncfusion.ExcelExport;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceDBProject.Services.Service
{
    public class DatabaseService : IDatabaseInterface
    {
        #region Excel To SQL

        public void ConvertCategoryExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {

                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string categoryName = row[1].ToString().Trim();
                        string categoryDescription = row[2].ToString().Trim();
                        DateTime dateCreated;

                        if (DateTime.TryParse(row[3].ToString().Trim(), out dateCreated))
                        {
                            using (var db = new EcommerceDbContext())
                            {
                                db.ProductCategories.Add(new ProductCategory
                                {
                                    CategoryName = categoryName,
                                    CategoryDescription = categoryDescription,
                                    DateCreated = dateCreated
                                });
                                //db.SaveChanges();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid date format in row {row}");
                        }
                    }
                }
            }
        }

        public void ConvertAddressExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string houseNumber = row[1].ToString().Trim();
                        string street = row[2].ToString().Trim();
                        string city = row[3].ToString().Trim();
                        string country = row[4].ToString().Trim();
                        string region = row[5].ToString().Trim();
                        string zipCode = row[6].ToString().Trim();

                        using (var db = new EcommerceDbContext())
                        {
                            db.Addresses.Add(new Address
                            {
                                HouseNumber = houseNumber,
                                Street = street,
                                City = city,
                                Country = country,
                                Region = region,
                                ZipCode = zipCode
                            });
                            //db.SaveChanges();
                        }
                    }
                }
            }
        }

        public void ConvertUserDetailExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string addressId = row[1].ToString().Trim();
                        string email = row[2].ToString().Trim();
                        string phoneNumber = row[3].ToString().Trim();
                        using (var db = new EcommerceDbContext())
                        {
                            db.UserDetails.Add(new UserDetail
                            {
                                AddressId = addressId,
                                Email = email,
                                PhoneNumber = phoneNumber
                            });
                            db.SaveChanges();
                        }
                    }

                }
            }
        }

        public void ConvertCustomerExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string firstName = row[1].ToString().Trim();
                        string LastName = row[2].ToString().Trim();
                        string userDetailId = row[4].ToString().Trim();
                        string password = row[7].ToString().Trim();
                        DateTime dateOfBirth;
                        DateTime lastLoginDate;
                        DateTime registrationDate;

                        if (DateTime.TryParse(row[5].ToString().Trim(), out dateOfBirth) &&
                            DateTime.TryParse(row[6].ToString().Trim(), out lastLoginDate) &&
                            DateTime.TryParse(row[3].ToString().Trim(), out registrationDate))
                        {
                            using (var db = new EcommerceDbContext())
                            {
                                db.Customers.Add(new Customer
                                {
                                    UserDetailId = userDetailId,
                                    FirstName = firstName,
                                    LastName = LastName,
                                    Password = password,
                                    RegistrationDate = registrationDate,
                                    LastLoginDate = lastLoginDate,
                                    DateOfBirth = new DateOnly(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                                });
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid date format in row {row}");
                        }
                    }

                }
            }
        }

        public void ConvertSellerExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string firstName = row[1].ToString().Trim();
                        string LastName = row[2].ToString().Trim();
                        DateTime registrationDate;
                        string userDetailId = row[5].ToString().Trim();
                        string password = row[6].ToString().Trim();

                        if (DateTime.TryParse(row[3].ToString().Trim(), out registrationDate))
                        {
                            using (var db = new EcommerceDbContext())
                            {
                                db.Sellers.Add(new Seller
                                {
                                    UserDetailId = userDetailId,
                                    FirstName = firstName,
                                    LastName = LastName,
                                    Password = password,
                                    RegistrationDate = registrationDate
                                });
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid date format in row {row}");
                        }
                    }

                }
            }
        }

        public void ConvertSupplierExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string firstName = row[1].ToString().Trim();
                        string LastName = row[2].ToString().Trim();
                        string supplierName = row[3].ToString().Trim();
                        string contactPersonPhoneNumber = row[4].ToString().Trim();
                        string userDetailId = row[5].ToString().Trim();

                        using (var db = new EcommerceDbContext())
                        {
                            db.Suppliers.Add(new Supplier
                            {
                                UserDetailId = userDetailId,
                                ContactPersonName = LastName + ", " + firstName,
                                SupplierName = supplierName,
                                ContactPersonPhoneNumber = contactPersonPhoneNumber
                            });
                            db.SaveChanges();
                        }
                    }

                }
            }
        }

        public void ConvertProductExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();
            int count = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string productName = row[1].ToString().Trim();
                        string productDescription = row[2].ToString().Trim();
                        double productPrice;
                        double productWeight;
                        string supplierId = row[5].ToString().Trim();
                        string categoryId = row[6].ToString().Trim();

                        if (double.TryParse(row[3].ToString().Trim(), out productPrice))
                        {
                            if (supplierId == "")
                            {
                                if (double.TryParse(row[4].ToString().Trim(), out productWeight))
                                {
                                    using (var db = new EcommerceDbContext())
                                    {
                                        db.Products.Add(new Product
                                        {
                                            ProductName = productName,
                                            ProductDescription = productDescription,
                                            Price = productPrice,
                                            ProductWeight = productWeight,
                                            CategoryId = categoryId
                                        });
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    using (var db = new EcommerceDbContext())
                                    {
                                        db.Products.Add(new Product
                                        {
                                            ProductName = productName,
                                            ProductDescription = productDescription,
                                            Price = productPrice,
                                            CategoryId = categoryId
                                        });
                                        db.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                if (double.TryParse(row[4].ToString().Trim(), out productWeight))
                                {
                                    using (var db = new EcommerceDbContext())
                                    {
                                        db.Products.Add(new Product
                                        {
                                            ProductName = productName,
                                            ProductDescription = productDescription,
                                            Price = productPrice,
                                            ProductWeight = productWeight,
                                            SupplierId = supplierId,
                                            CategoryId = categoryId
                                        });
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    using (var db = new EcommerceDbContext())
                                    {
                                        db.Products.Add(new Product
                                        {
                                            ProductName = productName,
                                            ProductDescription = productDescription,
                                            Price = productPrice,
                                            SupplierId = supplierId,
                                            CategoryId = categoryId
                                        });
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        public void ConvertPromotionExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        string promotionName = row[1].ToString().Trim();
                        string promotionDescription = row[2].ToString().Trim();
                        string startDateTemp = ConvertToSqlDateTime(row[3].ToString().Trim());
                        DateTime startDate;
                        DateTime endDate;
                        double discountPercentage;
                        if (double.TryParse(row[5].ToString().Trim(), out discountPercentage))
                        {
                            if (DateTime.TryParse(startDateTemp, out startDate))
                            {
                                using (var db = new EcommerceDbContext())
                                {
                                    if (DateTime.TryParse(row[4].ToString().Trim(), out endDate))
                                    {

                                        db.Promotions.Add(new Promotion
                                        {
                                            PromotionName = promotionName,
                                            PromotionDescription = promotionDescription,
                                            StartDate = startDate,
                                            EndDate = endDate,
                                            DiscountPercentage = discountPercentage
                                        });
                                    }
                                    else
                                    {
                                        db.Promotions.Add(new Promotion
                                        {
                                            PromotionName = promotionName,
                                            PromotionDescription = promotionDescription,
                                            StartDate = startDate,
                                            EndDate = GetRandomEndDateFromStartDateOfPromotion(startDate),
                                            DiscountPercentage = discountPercentage
                                        });
                                    }
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Invalid start date format in row {row}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid Discount Percentage format in row {row}");
                        }
                    }
                }
            }
        }


        #endregion

        #region Random Generate Functions

        public void GenerateRandomInventoryItems()
        {
            using (var db = new EcommerceDbContext())
            {
                var productsList = db.Products.ToList();
                var sellersList = db.Sellers.ToList();
                Random random = new Random();
                int count = 0;
                while (true)
                {
                    if(count == 1000 || count == 1000000000)
                    {
                        break;
                    }
                    var randomProduct = productsList[random.Next(productsList.Count)];
                    var randomSeller = sellersList[random.Next(sellersList.Count)];

                    if(!IsInventoryItemAlreadyExist(randomProduct, randomSeller))
                    {
                        int randomStockAmount = random.Next(100, 1101);
                        int randomPrice = random.Next(100, 500);
                        string randomCondition = random.Next(2) == 0 ? "Old" : "New";
                        db.InventoryItems.Add(new InventoryItem { 
                            SellerId = randomSeller.SellerId,
                            ProductId = randomProduct.ProductId,
                            SalePrice = randomProduct.Price + randomPrice,
                            StockAmount = randomStockAmount,
                            Condition = randomCondition
                        });
                        db.SaveChanges();
                        count++;
                    }
                }
            }
        }

        public void GenerateRandomOrders()
        {
            List<InventoryItem> inventoryItemList = new List<InventoryItem>();
            List<Customer> customerList = new List<Customer>();
            using (var db = new EcommerceDbContext())
            {
                inventoryItemList = db.InventoryItems.ToList();
                customerList = db.Customers.ToList();
            }
            Random random = new Random();

            for (int i = 0; i < 3000; i++)
            {
                var randomCustomer = customerList[random.Next(customerList.Count)];
                DateTime randomOrderDate = DateTime.Now.AddDays(-random.Next(1, 720));
                
                string shippingAddressId;
                using (var db = new EcommerceDbContext())
                {
                    shippingAddressId = db.UserDetails.FirstOrDefault(x => x.UserDetailId == randomCustomer.UserDetailId).AddressId;
                }

                var newOrder = new Order
                {
                    CustomerId = randomCustomer.CustomerId,
                    OrderDate = randomOrderDate,
                    TotalPrice = 0,
                    ShippingAddressId = shippingAddressId,
                    PaymentMethod = GetRandomPaymentMethod(random),
                    ShippingMethod = GetRandomShippingMethod(random)
                };

                double totalPrice = 0;
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach (var inventoryItem in inventoryItemList.OrderBy(x => Guid.NewGuid()).Take(random.Next(1, 6)))
                {
                    int randomQuantity = random.Next(1, 11);
                    if (randomQuantity > inventoryItem.StockAmount)
                    {
                        randomQuantity = inventoryItem.StockAmount - 1;
                    }
                    double unitPrice = inventoryItem.SalePrice;

                    using(var db = new EcommerceDbContext())
                    {
                        var productPromotions = db.ProductPromotions.Where(x => x.InventoryItemId == inventoryItem.InventoryItemId).ToList();
                        foreach (var productPromotion in productPromotions)
                        {
                            var promotion = db.Promotions.FirstOrDefault(x => x.PromotionId == productPromotion.PromotionId);
                            if (promotion.StartDate <= DateTime.Now && promotion.EndDate >= DateTime.Now)
                            {
                                unitPrice -= unitPrice * (promotion.DiscountPercentage / 100);
                                break;
                            }
                        }
                    }                    

                    DateTime? shippingDate = randomOrderDate.AddDays(random.Next(3, 11)) < DateTime.Now ? randomOrderDate.AddDays(random.Next(3, 11)) : null;
                    if (shippingDate == null)
                    {
                        var orderItem = new OrderItem
                        {
                            InventoryItemId = inventoryItem.InventoryItemId,
                            Quantity = randomQuantity,
                            UnitPrice = unitPrice,
                            IsReturned = false,
                            RequiredShippingDate = randomOrderDate.AddDays(7),
                            OrderStatus = "Pending"
                        };
                        orderItems.Add(orderItem);
                    }
                    else
                    {
                        var orderItem = new OrderItem
                        {
                            InventoryItemId = inventoryItem.InventoryItemId,
                            Quantity = randomQuantity,
                            UnitPrice = unitPrice,
                            IsReturned = false,
                            RequiredShippingDate = randomOrderDate.AddDays(7),
                            ShippingDate = shippingDate,
                            OrderStatus = "Delivered"
                        };
                        orderItems.Add(orderItem);
                    }
                    totalPrice += randomQuantity * unitPrice;
                }

                newOrder.TotalPrice = totalPrice;
                using (var db = new EcommerceDbContext())
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    foreach (var orderItem in orderItems)
                    {
                        orderItem.OrderId = newOrder.OrderId;
                        db.OrderItems.Add(orderItem);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void GenerateProductPromotions()
        {
            using (var db = new EcommerceDbContext())
            {
                var inventoryItemList = db.InventoryItems.ToList();
                var promotionList = db.Promotions.ToList();
                Random random = new Random();
                int count = 0;
                while(true)
                {
                    if(count == 1000 && count == 1000000000)
                    {
                        break;
                    }
                    var randomInventoryItem = inventoryItemList[random.Next(inventoryItemList.Count)];
                    var randomPromotion = promotionList[random.Next(promotionList.Count)];

                    var existingPromotion = db.ProductPromotions.FirstOrDefault(x => x.InventoryItemId == randomInventoryItem.InventoryItemId && x.PromotionId == randomPromotion.PromotionId);

                    if (existingPromotion == null)
                    {
                        db.ProductPromotions.Add(new ProductPromotion
                        {
                            PromotionId = randomPromotion.PromotionId,
                            InventoryItemId = randomInventoryItem.InventoryItemId
                        });
                        db.SaveChanges();
                    }
                }
            }
        }


        #endregion

        #region Helper Functions

        private bool IsInventoryItemAlreadyExist(Product product, Seller seller)
        {
            using(var db = new EcommerceDbContext())
            {
                var inventoryItem = db.InventoryItems.
                    FirstOrDefault(x => x.ProductId == product.ProductId && x.SellerId == seller.SellerId);
                if(inventoryItem == null)
                {
                    return false;
                }
                return true;
            }
        }

        private string GetRandomPaymentMethod(Random random)
        {
            string[] paymentMethods = { "Credit Card", "Cash On Delivery", "PayPal" };
            return paymentMethods[random.Next(paymentMethods.Length)];
        }

        private string GetRandomShippingMethod(Random random)
        {
            string[] shippingMethods = { "Express", "Standard", "Dhl" };
            return shippingMethods[random.Next(shippingMethods.Length)];
        }

        private DateTime GetRandomEndDateFromStartDateOfPromotion(DateTime startDate)
        {
            Random random = new Random();
            int randomDays = random.Next(7, 21);
            DateTime endDate = startDate.AddDays(randomDays);
            return endDate;
        }

        private string ConvertToSqlDateTime(string input)
        {
            string cleanedInput = input.Trim('{', '}', ' ');
            DateTime dateTime = DateTime.ParseExact(cleanedInput, "M/d/yyyy h:mm:ss tt", null);
            string sqlDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return sqlDateTime;
        }

        #endregion

        #region Extra Functions

        public void ConvertInventoryItemExcelToSQL(string filePath)
        {

            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string sellerId = row[1].ToString().Trim();
                    string productId = row[2].ToString().Trim();
                    string salePrice = row[3].ToString().Trim();
                    string stockAmount = row[4].ToString().Trim();
                    string condition = row[5].ToString().Trim();

                    using (var db = new EcommerceDbContext())
                    {
                        db.InventoryItems.Add(new InventoryItem
                        {
                            SellerId = sellerId,
                            ProductId = productId,
                            SalePrice = 0,//replace later
                            StockAmount = 1, //replace later
                            Condition = condition

                        });

                    }

                }
            }
        }

        public void ConvertInventoryItemPictureExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string pictureUrl = row[1].ToString().Trim();
                    string inventoryItemId = row[2].ToString().Trim();

                    using (var db = new EcommerceDbContext())
                    {
                        db.InventoryItemPictures.Add(new InventoryItemPicture
                        {
                            PictureUrl = pictureUrl,
                            InventoryItemId = inventoryItemId
                        });
                    }

                }
            }
        }

        public void ConvertOrderExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string customerId = row[1].ToString().Trim();
                    string totalPrice = row[2].ToString().Trim();
                    string shippingAddressId = row[2].ToString().Trim();
                    string shippingMethod = row[2].ToString().Trim();
                    string paymentMehod = row[2].ToString().Trim();
                    DateTime orderDate;
                    if (DateTime.TryParse(row[3].ToString().Trim(), out orderDate))
                    {

                        using (var db = new EcommerceDbContext())
                        {
                            db.Orders.Add(new Order
                            {
                                OrderDate = orderDate,
                                PaymentMethod = paymentMehod,
                                ShippingAddressId = shippingAddressId,
                                ShippingMethod = shippingMethod,
                                TotalPrice = 0,//replace later
                                CustomerId = customerId

                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {row}");
                    }
                }
            }
        }

        public void ConvertOrderItemExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string inventoryItemId = row[1].ToString().Trim();
                    string orderId = row[2].ToString().Trim();
                    string quantity = row[3].ToString().Trim();
                    string unitPrice = row[4].ToString().Trim();
                    string isReturned = row[5].ToString().Trim();
                    string orderStatus = row[6].ToString().Trim();
                    DateTime shippingDate;
                    DateTime requiredShippingDate = new DateTime();//replace later

                    if (DateTime.TryParse(row[7].ToString().Trim(), out shippingDate))
                    {

                        using (var db = new EcommerceDbContext())
                        {
                            db.OrderItems.Add(new OrderItem
                            {
                                OrderId = orderId,
                                InventoryItemId = inventoryItemId,
                                Quantity = int.Parse(quantity),
                                UnitPrice = double.Parse(unitPrice),
                                IsReturned = bool.Parse(isReturned),
                                OrderStatus = orderStatus,
                                ShippingDate = shippingDate,
                                RequiredShippingDate = requiredShippingDate

                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {row}");
                    }
                }
            }
        }

        public void ConvertProductPromotionExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string productId = row[1].ToString().Trim();
                    string inventoryItemId = row[2].ToString().Trim();


                    using (var db = new EcommerceDbContext())
                    {
                        db.ProductPromotions.Add(new ProductPromotion
                        {
                            InventoryItemId = inventoryItemId,
                            PromotionId = productId
                        });

                    }

                }
            }
        }

        public void ConvertProductReturnExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string orderItemId = row[1].ToString().Trim();
                    string returnReason = row[2].ToString().Trim();
                    string returnStatus = row[1].ToString().Trim();
                    string quantity = row[1].ToString().Trim();
                    DateTime returnDate;
                    if (DateTime.TryParse(row[3].ToString().Trim(), out returnDate))
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.ProductReturns.Add(new ProductReturn
                            {
                                OrderItemId = orderItemId,
                                ReturnStatus = returnStatus,
                                ReturnDate = returnDate,
                                ReturnReason = returnReason,
                                Quantity = 0//replace later
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid date format in row {row}");
                    }
                }
            }
        }

        public void ConvertProductReviewExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string orderItemId = row[1].ToString().Trim();
                    string reviewText = row[2].ToString().Trim();
                    string rating = row[3].ToString().Trim();
                    DateTime reviewDate;

                    if (DateTime.TryParse(row[4].ToString().Trim(), out reviewDate))
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.ProductReviews.Add(new ProductReview
                            {
                                OrderItemId = orderItemId,
                                ReviewText = reviewText,
                                ReviewDate = reviewDate,
                                Rating = 0//replace later
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid date format in row {row}");
                    }
                }
            }
        }

        #endregion
    }
}





  