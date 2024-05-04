using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForAddSupplier
    {
        public Address SupplierAddress { get; set; } = new();
        public UserDetail SupplierDetails { get; set; } = new();
        public Supplier Supplier { get; set; } = new();
    }
}
