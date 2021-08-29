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
    public partial class PaymentPage : ContentPage
    {
        PaymentViewModel model = null;
        public PaymentPage(DentistTreatmentAppointmentDTO DentistTreatmentAppointment)
        {
            InitializeComponent();
            this.Title = "Online payment";
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            BindingContext = model = new PaymentViewModel
            {
                DentistTreatmentAppointment = DentistTreatmentAppointment
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}