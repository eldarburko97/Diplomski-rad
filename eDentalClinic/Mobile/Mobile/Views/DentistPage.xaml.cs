using eDentalClinic.Model;
using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DentistPage : ContentPage
    {
        private DentistViewModel model = null;
        public DentistPage()
        {
            InitializeComponent();
            BindingContext = model = new DentistViewModel();
            this.Title = "Booking appointments";
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var dentist = e.Item as Dentist;
            if(dentist.Active == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This dentist is currently unavailable! Please select another dentist.", "OK");
                return;
            }
            await Navigation.PushAsync(new TreatmentPage(dentist));
        }
    }
}