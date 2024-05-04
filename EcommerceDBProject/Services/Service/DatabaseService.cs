using EcommerceDBProject.NewDatabase;
using EcommerceDBProject.Services.Interface;
using IronXL;
using Syncfusion.ExcelExport;
using System.Data;

namespace EcommerceDBProject.Services.Service
{
    public class DatabaseService : IDatabaseInterface
    {
        public void ConvertCategoryExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
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

        public void ConvertAddressExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
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
                        db.SaveChanges();
                    }
                }
            }
        }

        public void ConvertCustomerExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string userDetailId = row[1].ToString().Trim();
                    string firstName = row[2].ToString().Trim();
                    string LastName = row[3].ToString().Trim();
                    string password = row[4].ToString().Trim();
                    DateTime dateOfBirth;
                    DateTime lastLoginDate;
                    DateTime registrationDate;

                    if (DateTime.TryParse(row[5].ToString().Trim(), out dateOfBirth))


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
                                DateOfBirth = dateOfBirth
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
                            SalePrice = salePrice,
                            StockAmount = stockAmount,
                            Condition = condition

                        });

                    }

                }
            }
        }

        public void ConvertInvetoryItemPictureExcelToSQL(string filePath)
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
                                TotalPrice = totalPrice,
                                CustomerId = customerId

                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {line}");
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
                    DateTime requiredShippingDate;

                    if (DateTime.TryParse(row[7].ToString().Trim(), out shippingDate))
                    {

                        using (var db = new EcommerceDbContext())
                        {
                            db.OrderItems.Add(new OrderItem
                            {
                                OrderId = orderId,
                                InventoryItemId = inventoryItemId,
                                Quantity = quantity,
                                UnitPrice = unitPrice,
                                IsReturned = isReturned,
                                OrderStatus = orderStatus,
                                ShippingDate = shippingDate,
                                RequiredShippingDate = requiredShippingDate

                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {line}");
                    }
                }
            }
        }

        public void ConvertProductExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 7)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.Products.Add(new Product
                            {
                                ProductName = fields[1],
                                ProductDescription = fields[2],
                                ProductWeight = Double.Parse(fields[3]),
                                SupplierId = fields[4],
                                CategoryId = fields[5],
                                Price = double.Parse(fields[6])
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {line}");
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
                                Quantity = quantity
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
                                Rating = rating
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

        public void ConvertPromotionExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string promotionName = row[1].ToString().Trim();
                    string promotionDescription = row[2].ToString().Trim();
                    string discountPercentage = row[3].ToString().Trim();
                    DateTime startDate;
                    DateTime endDate;

                    if (DateTime.TryParse(row[4].ToString().Trim(), out startDate))
                    {
                        using (var db = new EcommerceDbContext())
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
                    }
                    else
                    {
                        Console.WriteLine($"Invalid date format in row {row}");
                    }
                }
            }


        }

        public void ConvertSellerExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string userDetailId = row[1].ToString().Trim();
                    string firstName = row[2].ToString().Trim();
                    string lastName = row[3].ToString().Trim();
                    string sellerRating = row[4].ToString().Trim();
                    string password = row[5].ToString().Trim();
                    DateTime registrationDate;
                    if (DateTime.TryParse(row[3].ToString().Trim(), out registrationDate))
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.Sellers.Add(new Seller
                            {
                                UserDetailId = userDetailId,
                                FirstName = firstName,
                                LastName = lastName,
                                RegistrationDate = registrationDate,
                                Password = password
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

        public void ConvertSupplierExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string userDetailId = row[1].ToString().Trim();
                    string supplierName = row[2].ToString().Trim();
                    string contactPersonName = row[2].ToString().Trim();
                    string contactPersonNumber = row[2].ToString().Trim();
                    using (var db = new EcommerceDbContext())
                    {
                        db.Suppliers.Add(new Supplier
                        {
                            UserDetailId = userDetailId,
                            SupplierName = supplierName,
                            ContactPersonName = contactPersonName,
                            ContactPersonPhoneNumber = contactPersonNumber
                        });

                    }

                }
            }
        }

        public void ConvertUserDetailExcelToSQL(string filePath)
        {
            WorkBook workBook = WorkBook.Load(filePath);
            DataSet dataSet = workBook.ToDataSet();

            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    string addressId = row[1].ToString().Trim();
                    string email = row[2].ToString().Trim();
                    string phoneNumber = row[2].ToString().Trim();
                    string picture = row[2].ToString().Trim();
                    using (var db = new EcommerceDbContext())
                    {
                        db.UserDetails.Add(new UserDetail
                        {
                            AddressId = addressId,
                            Email = email,
                            PhoneNumber = phoneNumber,
                            Picture = picture

                        });
                        db.SaveChanges();
                    }
                }

            }
        }


    }
}







  