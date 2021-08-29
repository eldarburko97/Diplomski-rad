using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
   public class DentistRatingViewModel : BaseViewModel
    {
        private readonly APIService _appointmentService = new APIService("Appointments");
        private readonly APIService _userService = new APIService("Users");
        public DentistRatingViewModel()
        {

        }

        public ObservableCollection<Appointment> AppointmentList { get; set; } = new ObservableCollection<Appointment>();

        public async Task Init()
        {
            if(AppointmentList.Count > 0)
            {
                AppointmentList.Clear();
            }
            var list = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username });
            var client = list[0];

            AppointmentSearchRequest request = new AppointmentSearchRequest
            {
                UserID = client.UserID
            };

            var appointments = await _appointmentService.GetAll<List<Appointment>>(request);

            foreach (var appointment in appointments)
            {
                if(appointment.RatingStatus == false && appointment.StartDate.Date <= DateTime.Now.Date)
                {
                    AppointmentList.Add(appointment);
                }
            }

            if(AppointmentList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "The list is empty. You can leave a rating on the booked appointment after the appointment expires or you have not booked yet.", "OK");
            }
        }
    }
    
}
