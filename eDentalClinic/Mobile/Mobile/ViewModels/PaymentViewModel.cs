using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        private readonly APIService _paymentService = new APIService("Payments");
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _dentistService = new APIService("Dentists");
        private readonly APIService _treatmentService = new APIService("Treatments");
        private readonly APIService _appointmentService = new APIService("Appointments");
        public PaymentViewModel()
        {
            AddPaymentCommand = new Command(async () => await AddPayment());
        }

        public ICommand AddPaymentCommand { get; set; }

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

        string _dentist = string.Empty;  //First name + last name
        public string Dentist
        {
            get { return _dentist; }
            set { SetProperty(ref _dentist, value); }
        }

        string _treatmentName = string.Empty;
        public string TreatmentName
        {
            get { return _treatmentName; }
            set { SetProperty(ref _treatmentName, value); }
        }

        decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        string _creditCardNumber = string.Empty;
        public string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { SetProperty(ref _creditCardNumber, value); }
        }

        DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public DentistTreatmentAppointmentDTO DentistTreatmentAppointment { get; set; }

        public async Task Init()
        {
            var client = await _userService.GetById<User>(DentistTreatmentAppointment.UserID);
            FirstName = client.FirstName;
            LastName = client.LastName;
            Phone = client.Phone;
            Email = client.Email;

            var dentist = await _dentistService.GetById<Dentist>(DentistTreatmentAppointment.DentistID);
            Dentist = dentist.FirstName + " " + dentist.LastName;

            var treatment = await _treatmentService.GetById<Treatment>(DentistTreatmentAppointment.TreatmentID);
            TreatmentName = treatment.Name;
            Amount = treatment.Price;
        }

        async Task AddPayment()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CreditCardNumber))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Credit card number field is required !", "OK");
                    return;
                }
                var client = await _userService.GetById<User>(DentistTreatmentAppointment.UserID);
                var dentist = await _dentistService.GetById<Dentist>(DentistTreatmentAppointment.DentistID);
                var treatment = await _treatmentService.GetById<Treatment>(DentistTreatmentAppointment.TreatmentID);

                AppointmentInsertRequest request = new AppointmentInsertRequest
                {
                    UserID = client.UserID,
                    DentistID = dentist.DentistID,
                    TreatmentID = treatment.TreatmentID,
                    StartDate = DentistTreatmentAppointment.StartDate,
                    EndDate = DentistTreatmentAppointment.StartDate.AddHours(DentistTreatmentAppointment.TimeRequired),
                    RatingStatus = false,
                };
                var result = await _appointmentService.Insert<Appointment>(request);

                if (result == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Appointment already booked! Please book another appointment", "OK");
                    return;
                }
                else
                {
                    await _paymentService.Insert<Payment>(new PaymentInsertRequest
                    {
                        UserID = client.UserID,
                        TreatmentID = treatment.TreatmentID,
                        Amount = treatment.Price,
                        Date = Date
                    });
                    await Application.Current.MainPage.DisplayAlert("Success", "You have successfully booked an appointment!", "OK");
                    Application.Current.MainPage = new MainPage();
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Somethning went wrong", "OK");
            }
        }
    }
}
