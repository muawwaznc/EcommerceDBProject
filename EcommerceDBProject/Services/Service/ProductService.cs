using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class ProductService : IProductInterface
    {
        public List<ComboBoxItemsViewModel> GetAllCategoriesForDropDown()
        {
            var db = new EcommerceDbContext();
            var ProductCategories = db.ProductCategories.ToList();
            var ProductCategoriesList = new List<ComboBoxItemsViewModel>();
            foreach (var category in ProductCategories)
            {
                ProductCategoriesList.Add(new ComboBoxItemsViewModel
                {
                    Value = category.CategoryId,
                    Text = category.CategoryName
                });
            }
            return ProductCategoriesList;
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            var db = new EcommerceDbContext();
            var ProductCategories = db.ProductCategories.ToList();
            return ProductCategories;
        }
        
        public Product GetProductFromProductId(string productId)
        {
            using (var db = new EcommerceDbContext())
            {
                var product = db.Products.FirstOrDefault(x => x.ProductId == productId);
                return product;
            }
        }

        public Product GetProductFromInventoryItemId(string inventoryItemId)
        {
            using (var db = new EcommerceDbContext())
            {
                var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);
                var product = db.Products.FirstOrDefault(x => x.ProductId == inventoryItem.ProductId);
                return product;
            }
        }
        
        public void AddProductCategory(ProductCategory category)
        {
            using (var db = new EcommerceDbContext())
            {
                db.ProductCategories.Add(category);
                db.SaveChanges();
            }
        }

        public bool IsCategoryNameAlreadyExist(string categoryName)
        {
            var categoryList = GetAllProductCategories();
            foreach (var item in categoryList)
            {
                if (item.CategoryName == categoryName)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Supplier> GetAllSuppliers()
        {
            using (var db = new EcommerceDbContext())
            {
                var suppliersList = db.Suppliers.ToList();
                return suppliersList;
            }                
        }

        public void AddProduct(Product product)
        {
            using(var db = new EcommerceDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using(var db = new EcommerceDbContext())
            {
                var products = db.Products.ToList();
                return products;
            }
        }

        public List<Product> GetAllProductsByCategoryId(string categoryId)
        {
            using (var db = new EcommerceDbContext())
            {
                var products = db.Products.Where(x => x.CategoryId == categoryId).ToList();
                return products;
            }
        }

        public ProductCategory GetProductCategoryByCategoryId(string categoryId)
        {
            using(var db = new EcommerceDbContext())
            {
                var category = db.ProductCategories.FirstOrDefault(x => x.CategoryId == categoryId);
                return category;
            }
        }

        public Supplier GetSupplierBySupplierId(string supplierId)
        {
            using (var db = new EcommerceDbContext())
            {
                var supplier = db.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId);
                return supplier;
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var db = new EcommerceDbContext())
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }

        public void UpdateProductCategory(ProductCategory productCategory)
        {
            using (var db = new EcommerceDbContext())
            {
                db.ProductCategories.Update(productCategory);
                db.SaveChanges();
            }
        }

        public bool DeleteProduct(Product product)
        {
            using (var db = new EcommerceDbContext())
            {
                try
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteProductCategory(ProductCategory productCategory)
        {
            using (var db = new EcommerceDbContext())
            {
                try
                {
                    db.ProductCategories.Remove(productCategory);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<ProductViewModel> RefreshProductsList()
        {
            var products = GetAllProducts();
            var productsList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsList.Add(new ProductViewModel
                {
                    Product = product,
                    Category = GetProductCategoryByCategoryId(product.CategoryId),
                    Supplier = product.SupplierId != null ? GetSupplierBySupplierId(product.SupplierId) : null
                });
            }
            return productsList;
        }
    }
}
