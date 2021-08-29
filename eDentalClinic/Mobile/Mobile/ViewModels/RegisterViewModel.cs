using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using Flurl.Http;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _cityService = new APIService("Cities");
        private readonly APIService _genderService = new APIService("Genders");
        private readonly APIService _userRoleService = new APIService("UserRoles");

        UserInsertRequest insert_request = new UserInsertRequest();
        UserRoleInsertRequest insert_request2 = new UserRoleInsertRequest();
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
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

        string _passwordConfirm = string.Empty;
        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { SetProperty(ref _passwordConfirm, value); }
        }

        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
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

        string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        DateTime _birthdate;
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { SetProperty(ref _birthdate, value); }
        }

        City _selectedCity = null;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                SetProperty(ref _selectedCity, value);
            }
        }

        Gender _selectedGender = null;
        public Gender SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                SetProperty(ref _selectedGender, value);
            }
        }

        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        public ObservableCollection<Gender> Genders { get; set; } = new ObservableCollection<Gender>();
        public ICommand RegisterCommand { get; set; }

        public async Task Init()
        {
            var citiesList = await _cityService.GetAll<List<City>>(null);
            foreach (var city in citiesList)
            {
                Cities.Add(city);
            }

            var gendersList = await _genderService.GetAll<List<Gender>>(null);
            foreach (var gender in gendersList)
            {
                Genders.Add(gender);
            }
        }

        async Task Register()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Username) ||
                    string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(PasswordConfirm) || string.IsNullOrWhiteSpace(Phone) ||
                    string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Address) || SelectedCity.CityID == 0 || SelectedGender.GenderID == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required !", "OK");
                    return;
                }

                if (Password != PasswordConfirm)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password don't match !", "OK");
                    return;
                }

                insert_request.FirstName = FirstName;
                insert_request.LastName = LastName;
                insert_request.Username = Username;
                insert_request.Password = Password;
                insert_request.ConfirmPassword = PasswordConfirm;
                insert_request.Phone = Phone;
                insert_request.Email = Email;
                insert_request.Address = Address;
                insert_request.BirthDate = Birthdate.Date;
                insert_request.CityID = SelectedCity.CityID;
                insert_request.GenderID = SelectedGender.GenderID;
                insert_request.DentalClinicID = 1;

                Assembly a = Assembly.GetExecutingAssembly();
                string fileName = a.GetName().Name + "." + "userDefault.png";
                using (Stream resFilestream = a.GetManifestResourceStream(fileName))
                {
                    if (resFilestream != null)
                    {
                        var ms = new MemoryStream();
                        await resFilestream.CopyToAsync(ms);
                        var bytes = ms.ToArray();
                        insert_request.Image = bytes;
                    }
                }

                var result = await _userService.Insert<User>(insert_request);
                insert_request2.UserID = result.UserID;
                insert_request2.RoleID = 2;
                await _userRoleService.Insert<UserRole>(insert_request2);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered!", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }

            catch (FlurlHttpException ex)
            {
                var status = ex.Call.HttpStatus;
                var result = await ex.GetResponseStringAsync();

                if (status == System.Net.HttpStatusCode.BadRequest)
                {
                    if (result.Contains("Duplicate user"))
                    {
                        var message = "Cannot insert duplicate username !";
                        await Application.Current.MainPage.DisplayAlert("Error",message,"OK");
                    }
                    else
                    {
                        var message = "All fields are required !";
                        await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                    }
                }
            }
        }
    }
}
