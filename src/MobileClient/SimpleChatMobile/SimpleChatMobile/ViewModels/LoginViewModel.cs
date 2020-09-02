using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleChatMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        public event EventHandler SuccessLogin;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand =>
            _loginCommand ??= new Command(OnLogin);

        private void OnLogin()
        {
            SuccessLogin?.Invoke(this, EventArgs.Empty);
        }

        private string _login;

        private ICommand _loginCommand;
    }
}
