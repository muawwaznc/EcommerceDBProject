using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Service
{
    public class ProductService : IProductInterface
    {
        public List<ComboBoxItemsViewModel> GetAllCategoriesForDropDown()
        {
            var db = new EcommerceDbprojectContext();
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
            var db = new EcommerceDbprojectContext();
            var ProductCategories = db.ProductCategories.ToList();
            return ProductCategories;
        }
        
        public Product GetProductFromProductId(string productId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var product = db.Products.FirstOrDefault(x => x.ProductId == productId);
                return product;
            }
        }

        public ProductCategory GetProductCategoryFromProductCategoryId(string categoryId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var productCategory = db.ProductCategories.FirstOrDefault(x => x.CategoryId == categoryId);
                return productCategory;
            }
        }

        public Product GetProductFromInventoryItemId(string inventoryItemId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);
                var product = db.Products.FirstOrDefault(x => x.ProductId == inventoryItem.ProductId);
                return product;
            }
        }
        
        public void AddProductCategory(ProductCategory category)
        {
            using (var db = new EcommerceDbprojectContext())
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
            using (var db = new EcommerceDbprojectContext())
            {
                var suppliersList = db.Suppliers.ToList();
                return suppliersList;
            }                
        }

        public void AddProduct(Product product)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
    }
}
