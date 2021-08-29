using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using eDentalClinic.Model.Requests;
using eDentalClinic.Model;
using Xamarin.Essentials;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalDataPage : ContentPage
    {
        private PersonalDataViewModel model = null;
        private readonly APIService _service = new APIService("Users");
        public PersonalDataPage()
        {
            InitializeComponent();
            Title = "Personal data";
            BindingContext = model = new PersonalDataViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // await Application.Current.MainPage.DisplayAlert("You have successfully registered!", "", "OK");
            
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an image"
            });
            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                var ms = new MemoryStream();
                stream.CopyTo(ms);
                var byteArray = ms.ToArray();
                // resultImage.Source = ImageSource.FromStream(() => stream);
                UserSearchRequest searchRequest = new UserSearchRequest { Username = APIService.Username };
                var users = await _service.GetAll<List<User>>(searchRequest);
                var user = users[0];
                UserInsertRequest userInsertRequest = new UserInsertRequest
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Email = user.Email,
                    Address = user.Address,
                    BirthDate = user.BirthDate.Date,
                    Image = byteArray,
                    DentalClinicID = user.DentalClinicID,
                   CityID = user.CityID,
                   GenderID = user.GenderID
                };
                await _service.Update<User>(user.UserID, userInsertRequest);
                await Application.Current.MainPage.DisplayAlert("", "You have successfully changed your profile picture !", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}