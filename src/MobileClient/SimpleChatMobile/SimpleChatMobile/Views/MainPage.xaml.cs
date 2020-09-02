using SimpleChatMobile.ViewModels;
using Xamarin.Forms;

namespace SimpleChatMobile.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string login)
        {
            InitializeComponent();

            _viewModel = BindingContext as MainPageViewModel;
            _viewModel.UserName = login;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnViewAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.OnViewDisappearing();
        }

        private readonly MainPageViewModel _viewModel;
    }
}
