using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Mobile.Views;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            // IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                 await _service.GetAll<dynamic>(null);
                //await _service.GetById<dynamic>(0);
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception)
            {
            }
        }
    }
}
