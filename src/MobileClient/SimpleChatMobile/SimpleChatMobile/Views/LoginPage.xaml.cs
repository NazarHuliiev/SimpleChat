using SimpleChatMobile.ViewModels;
using Xamarin.Forms;

namespace SimpleChatMobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            _viewModel = BindingContext as LoginViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.SuccessLogin += OnSuccessLogin;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.SuccessLogin -= OnSuccessLogin;
        }

        private void OnSuccessLogin(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage(_viewModel.Login);
        }

        private readonly LoginViewModel _viewModel;
    }
}
