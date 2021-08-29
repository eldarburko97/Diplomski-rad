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
    public partial class RatingPage : ContentPage
    {
        RatingViewModel model = null;
        public RatingPage(Appointment appointment)
        {
            InitializeComponent();
            this.Title = "Rating";
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new RatingViewModel
            {
                Appointment = appointment,
                Dentist = appointment.Dentist,
                Treatment = appointment.Treatment
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}