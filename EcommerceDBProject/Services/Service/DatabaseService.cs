using EcommerceDBProject.NewDatabase;
using EcommerceDBProject.Services.Interface;
using IronXL;
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
                            db.Addresses.Add(new Address
                            {
                                HouseNumber = fields[1],
                                Street = fields[2],
                                City = fields[3],
                                Country = fields[4],
                                Region = fields[5],
                                ZipCode = fields[6]
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

        public void ConvertCustomerExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 8)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.Customers.Add(new Customer
                            {
                                FirstName = fields[0],
                                LastName = fields[1],
                                RegistrationDate = DateTime.Parse(fields[2]),
                                LastLoginDate = DateTime.Parse(fields[6]),
                                DateOfBirth = DateOnly.Parse(fields[5]),
                                Password = fields[7],
                                UserDetailId = fields[3]
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

        public void ConvertInventoryItemExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 6)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.InventoryItems.Add(new InventoryItem
                            {
                                SellerId = fields[1],
                                ProductId = fields[2],
                                SalePrice = double.Parse(fields[3]),
                                StockAmount = int.Parse(fields[4]),
                                Condition = fields[5]

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

        public void ConvertInvetoryItemPictureExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 3)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.InventoryItemPictures.Add(new InventoryItemPicture
                            {
                                PictureUrl = fields[1],
                                InventoryItemId = fields[2]
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

        public void ConvertOrderExcelToSQL(string filePath)
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
                            db.Orders.Add(new Order
                            {
                                OrderDate = DateTime.Parse(fields[1]),
                                PaymentMethod = fields[2],
                                ShippingAddressId = fields[3],
                                ShippingMethod = fields[4],
                                TotalPrice = double.Parse(fields[5]),
                                CustomerId = fields[6]

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
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 9)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.OrderItems.Add(new OrderItem
                            {
                                OrderId= fields[1],
                                InventoryItemId = fields[2],
                                Quantity = int.Parse(fields[3]),
                                UnitPrice = double.Parse(fields[4]),
                                IsReturned = bool.Parse(fields[5]),
                                OrderStatus = fields[6],
                                ShippingDate = DateTime.Parse(fields[7]),
                                RequiredShippingDate = DateTime.Parse(fields[8])

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
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 3)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.ProductPromotions.Add(new ProductPromotion
                            {
                                InventoryItemId = fields[1],
                                PromotionId = fields[2]
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

        public void ConvertProductReturnExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 6)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.ProductReturns.Add(new ProductReturn
                            {
                                OrderItemId = fields[1],
                                ReturnStatus= fields[2],
                                ReturnDate = DateTime.Parse(fields[3]),
                                ReturnReason= fields[4],
                                Quantity = int.Parse(fields[5])
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

        public void ConvertProductReviewExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 5)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.ProductReviews.Add(new ProductReview
                            {
                                OrderItemId = fields[1],
                                ReviewText = fields[2],
                                ReviewDate = DateTime.Parse(fields[3]),
                                Rating = int.Parse(fields[4])
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

        public void ConvertPromotionExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 6)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.Promotions.Add(new Promotion
                            {
                                PromotionName = fields[4],
                                PromotionDescription = fields[1],
                                StartDate= DateTime.Parse(fields[2]),
                                EndDate= DateTime.Parse(fields[3]),
                                DiscountPercentage = int.Parse(fields[5])
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

        public void ConvertSellerExcelToSQL(string filePath)
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
                            db.Sellers.Add(new Seller
                            {
                                UserDetailId = fields[5],
                                FirstName = fields[1],
                                LastName = fields[2],
                                RegistrationDate = DateTime.Parse(fields[3]),
                                SellerRating = int.Parse(fields[4]),
                                Password = fields[6]
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

        public void ConvertSupplierExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 5)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.Suppliers.Add(new Supplier
                            {
                                SupplierName = fields[3],
                                ContactPersonName = fields[1],
                                ContactPersonPhoneNumber = fields[2],
                                UserDetailId= fields[4]
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

        public void ConvertUserDetailExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 4)
                    {
                        using (var db = new EcommerceDbContext())
                        {
                            db.UserDetails.Add(new UserDetail
                            {
                                AddressId = fields[1],
                                Email = fields[2],
                                PhoneNumber= fields[3],
                                Picture= "User Picture"
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









    }
}
