using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages
{
    public partial class Home : ComponentBase
    {
        #region Injection

        IUserInterface UserService { get; set; }

        #endregion

        #region Css Properties

        protected string CssForSignInNav = "";
        protected string CssForSignUpNav = "";

        #endregion

        #region Properties

        protected InitialPageDataForHomePage InitialPageData { get; set; } = new();
        protected SignInModel? SignInModel { get; set; } = new();
        protected SignUpModel? SignUpModel { get; set; } = new();
        protected AddressModel? AddressModel { get; set; } = new();
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
            AddressModel = SignUpModel.Address;
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
            var isAuthenicatedUser = UserService.IsAuthenicated(SignInModel.Email, SignInModel.Password);
            if (isAuthenicatedUser == null)
            {

            }
        }

        public void SignUp()
        {

        }

        #endregion

        #region OnChange Functions

        private void HandleUserRoleRadioChange(string value)
        {
            SignUpModel.UserRole = value;
        }

        #endregion
    }
}
