namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataforUpdateDeleteSupplier
    {
        public List<SupplierInfoViewModel> SupplierList = new List<SupplierInfoViewModel>();
        public bool IsEditDialogBoxOpen { get; set; }
        public SupplierInfoViewModel SelectedSupplier { get; set; }

        public class SupplierInfoViewModel
        {
            public string SupplierId { get; set; }
            public string SupplierName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string ContactPersonName { get; set; } = null!;

            public string ContactPersonPhoneNumber { get; set; } = null!;
        }



    }
}
