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
    public partial class MyAppointmentsPage : ContentPage
    {
        private readonly APIService _appointmentService = new APIService("Appointments");
        MyAppointmentsViewModel model = null;
        public MyAppointmentsPage()
        {
            InitializeComponent();
            BindingContext = model = new MyAppointmentsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var appointment = button.BindingContext as Appointment;
            model.CancelCommand.Execute(appointment);
        }
    }
}