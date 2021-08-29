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
    public partial class DentistRating : ContentPage
    {
        DentistRatingViewModel model = null;
        public DentistRating()
        {
            InitializeComponent();
            Title = "Booked appointments";
            NavigationPage.SetHasNavigationBar(this, true);
            //NavigationPage.SetHasBackButton(this, true);
            BindingContext = model = new DentistRatingViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var appointment = e.Item as Appointment;

            await Navigation.PushAsync(new RatingPage(appointment));
        }
    }
}