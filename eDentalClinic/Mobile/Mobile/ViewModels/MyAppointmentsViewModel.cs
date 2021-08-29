using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class MyAppointmentsViewModel : BaseViewModel
    {
        private readonly APIService _appointmentService = new APIService("Appointments");
        private readonly APIService _userService = new APIService("Users");
        public MyAppointmentsViewModel()
        {
            SearchAppointmentsCommand = new Command(async () => await SearchAppointments());
            CancelCommand = new Command(async (appointment) => { await Cancel(appointment); });
        }

        public ICommand SearchAppointmentsCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ObservableCollection<Appointment> AppointmentList { get; set; } = new ObservableCollection<Appointment>();

        string _treatmentName = string.Empty;
        public string TreatmentName
        {
            get { return _treatmentName; }
            set { SetProperty(ref _treatmentName, value); }
        }

        DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        DateTime _endDate = DateTime.Now.Date;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        public async Task Init()
        {
            UserSearchRequest request = new UserSearchRequest { Username = APIService.Username };
            var list = await _userService.GetAll<List<User>>(request);
            var client = list[0];

            if (AppointmentList.Count > 0)
            {
                AppointmentList.Clear();
            }

            AppointmentSearchRequest request2 = new AppointmentSearchRequest { UserID = client.UserID };
            var appointments = await _appointmentService.GetAll<List<Appointment>>(request2);

            foreach (var appointment in appointments)
            {
                AppointmentList.Add(appointment);
            }

            if (AppointmentList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "You don't have any appointments yet.", "OK");
            }
        }

        async Task SearchAppointments()
        {
            if (EndDate < StartDate)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "End date must be greater than start date", "Try again");
                return;
            }

            UserSearchRequest request = new UserSearchRequest { Username = APIService.Username };
            var list = await _userService.GetAll<List<User>>(request);
            var client = list[0];

            if (AppointmentList.Count > 0)
            {
                AppointmentList.Clear();
            }

            AppointmentSearchRequest request2 = new AppointmentSearchRequest
            {
                UserID = client.UserID,
                TreatmentName = TreatmentName,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date
            };

            var appointments = await _appointmentService.GetAll<List<Appointment>>(request2);

            foreach (var appointment in appointments)
            {
                AppointmentList.Add(appointment);
            }

            if (AppointmentList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "There are no results for this search", "OK");
            }

        }

        async Task Cancel(object appointment)
        {

            try
            {
                var item = appointment as Appointment;
                if (item.StartDate.Date == DateTime.Now.Date)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You cannot cancel an appointment on the day of the appointment !", "OK");
                    return;
                }

                if (item.StartDate.Date < DateTime.Now.Date)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You cannot cancel already completed appointments !", "OK");
                    return;
                }
                await _appointmentService.Delete<Appointment>(item.AppointmentID);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully cancelled your request", "OK");
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Somethning went wrong", "OK");
            }
        }

    }
}
