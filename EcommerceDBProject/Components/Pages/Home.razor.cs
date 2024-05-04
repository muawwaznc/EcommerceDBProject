using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;
using EcommerceDBProject.Enum;
using Blazored.Toast.Services;

namespace EcommerceDBProject.Components.Pages
{
    public partial class Home : ComponentBase
    {
        #region Injection

        [Inject] IUserInterface UserService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Css Properties

        protected string CssForSignInNav = "";
        protected string CssForSignUpNav = "";

        #endregion

        #region Properties

        protected InitialPageDataForHomePage InitialPageData { get; set; } = new();
        protected SignInModel? SignInModel { get; set; } = new();
        protected SignUpModel? SignUpModel { get; set; } = new();
        protected Address? Address { get; set; } = new();
        protected bool isSignInActive { get; set; } = false;
        protected bool isSignUpActive { get; set; } = false;

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            isSignInActive = true;
            CssForSignInNav = "active";
            SignInModel = InitialPageData.SignInModel;
            SignUpModel = InitialPageData.SignUpModel;
            Address = SignUpModel.Address;
        }

        #endregion

        #region OnClick Functions

        public void OnSignInTabClick()
        {
            CssForSignInNav = "active";
            CssForSignUpNav = "";
            isSignInActive = true;
            isSignUpActive = false;
        }

        public void OnSignUpTabClick()
        {
            CssForSignInNav = "";
            CssForSignUpNav = "active";
            isSignInActive = false;
            isSignUpActive = true;
        }

        #endregion

        #region Authenication Function

        public void SignIn()
        {
            InitialPageData.IsLoading = true;
            if (SignInValidation())
            {
                try
                {
                    ToastService.ShowInfo("Loading...");
                    if(SignInModel.Email == "warda😎@gmail.com" && SignInModel.Password == "crib")
                    {
                        NavigationManager.NavigateTo("/admin/add-category");
                        InitialPageData.IsLoading = false;
                        return;
                    }
                    var isAuthenicatedUser = UserService.IsAuthenicated(SignInModel.Email, SignInModel.Password);
                    if (isAuthenicatedUser == null)
                    {
                        ToastService.ShowError("Invalid Credentials");
                        InitialPageData.IsLoading = false;
                        return;
                    }
                    var userRole = UserService.GetUserRoleByUserDetailId(isAuthenicatedUser.UserDetailId);
                    if(userRole == UserRole.Customer)
                    {
                        NavigationManager.NavigateTo("/customer-dashboard/" + isAuthenicatedUser.UserDetailId);
                        InitialPageData.IsLoading = false;
                        return;
                    }
                    else if(userRole == UserRole.Seller)
                    {
                        NavigationManager.NavigateTo("/seller-dashboard/" + isAuthenicatedUser.UserDetailId);
                        InitialPageData.IsLoading = false;
                        return;
                    }
                    InitialPageData.IsLoading = false;
                    NavigationManager.NavigateTo("/Error");
                }
                catch (Exception ex)
                {
                    InitialPageData.IsLoading = false;
                    NavigationManager.NavigateTo("/Error");
                }
            }            
        }

        public void SignUp()
        {
            if (SignUpValidation())
            {
                var isAuthenicatedUser = UserService.SignUp(SignUpModel);
                if (isAuthenicatedUser == null)
                {
                    ToastService.ShowError("Something went wrong... Try Again...");
                }
                else
                {
                    ToastService.ShowError("Signup Successfully");
                }

            }
        }

        #endregion

        #region OnChange Functions

        private void HandleUserRoleRadioChange(string value)
        {
            SignUpModel.UserRole = value;
        }

        #endregion

        #region Validation Functions

        public bool SignInValidation()
        {
            if (SignInModel.Email == null || SignInModel.Password == null)
            {
                return false;
            }
            return true;
        }

        public bool SignUpValidation()
        {
            if (SignUpModel.FirstName == null || SignUpModel.LastName == null ||
                SignUpModel.Email == null || SignUpModel.PhoneNumber == null ||
                SignUpModel.Password == null || SignUpModel.UserRole == null)
            {
                if(SignUpModel.UserRole == "customer" && SignUpModel.DateOfBirth == null)
                {
                    return false;
                }
                return false;
            }
            return true;
        }

        #endregion
    }
}
