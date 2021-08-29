using eDentalClinic.Model.Requests;
using Flurl.Http;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users");
        public SettingsViewModel()
        {
            ShowCommand = new Command(() =>
            {
                EntryVisible = true;
            });

            HideCommand = new Command(() =>
            {
                EntryVisible = false;
            });

            ChangePasswordCommand = new Command(async () =>

                  await ChangePassword()
              );

            UpdateCommand = new Command(async () => await Update());
        }

        string _password = string.Empty; 
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _confirmPassword = string.Empty; 
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }

        string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        bool _entryVisible = false;
        public bool EntryVisible
        {
            get { return _entryVisible; }
            set { SetProperty(ref _entryVisible, value); }
        }

        public ICommand ShowCommand { get; set; }

        public ICommand HideCommand { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public async Task Init()
        {
            UserSearchRequest request = new UserSearchRequest
            {
                Username = APIService.Username
            };
            var list = await _service.GetAll<List<eDentalClinic.Model.User>>(request);
            foreach (var user in list)
            {
                Phone = user.Phone;
                Email = user.Email;
            }
        }

        async Task ChangePassword()
        {
            try
            {
                if (Password != ConfirmPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password and password confirm doesn't match !", "OK");
                    return;
                }

                if(string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password and password confirm field are required !", "OK");
                    return;
                }
                UserSearchRequest request = new UserSearchRequest
                {
                    Username = APIService.Username
                };
                var list = await _service.GetAll<List<eDentalClinic.Model.User>>(request);
                var id = list[0].UserID;
                var user = list[0];
                UserInsertRequest request2 = new UserInsertRequest
                {
                    Password = Password,
                    ConfirmPassword = ConfirmPassword,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Email = user.Email,
                    Address = user.Address,
                    BirthDate = user.BirthDate.Date,
                    DentalClinicID = user.DentalClinicID,
                    CityID = user.CityID,
                    GenderID = user.GenderID,
                    Image = user.Image
                };

                var returned_user = await _service.Update<eDentalClinic.Model.User>(id, request2);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully changed your password !", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            catch (FlurlHttpException ex)
            {
                var status = ex.Call.HttpStatus;
                var result = await ex.GetResponseStringAsync();
                if (status == System.Net.HttpStatusCode.BadRequest)
                {
                    var message = "Password and password confirm doesn't match !";
                    await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }            
        }

        async Task Update()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required !", "OK");
                    return;
                }
                UserSearchRequest request = new UserSearchRequest
                {
                    Username = APIService.Username
                };
                var list = await _service.GetAll<List<eDentalClinic.Model.User>>(request);
                var id = list[0].UserID;
                var user = list[0];
                UserInsertRequest request2 = new UserInsertRequest
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = Email,
                    Phone = Phone,
                    Address = user.Address,
                    BirthDate = user.BirthDate.Date,
                    DentalClinicID = user.DentalClinicID,
                    CityID = user.CityID,
                    GenderID = user.GenderID,
                    Image = user.Image
                };

                var returned_user = await _service.Update<eDentalClinic.Model.User>(id, request2);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully updated your information !", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            catch (FlurlHttpException ex)
            {
                var status = ex.Call.HttpStatus;
                var result = await ex.GetResponseStringAsync();
                if(status == System.Net.HttpStatusCode.BadRequest)
                {
                    var message = "All fields are required !";
                    await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }                
            }
        }
    }
}
