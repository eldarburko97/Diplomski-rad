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
    public partial class TreatmentPage : ContentPage
    {
        private TreatmentViewModel model = null;
        public TreatmentPage()
        {
            InitializeComponent();
        }
        public TreatmentPage(Dentist dentist)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            BindingContext = model = new TreatmentViewModel
            {
                dentist = dentist
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Treatment treatment = e.Item as Treatment;
            await Navigation.PushAsync(new BookingAppointmentPage(new DentistTreatmentDTO {DentistID = model.dentist.DentistID,TreatmentID = treatment.TreatmentID,Name = treatment.Name,TimeRequired = treatment.TimeRequired }));
        }
    }
}