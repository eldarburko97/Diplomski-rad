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
    public class RatingViewModel : BaseViewModel
    {
        private readonly APIService _ratingService = new APIService("Ratings");
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _appointmentService = new APIService("Appointments");
        public RatingViewModel()
        {
            RatingCommand = new Command(async () => await AddRating());
        }

        public ICommand RatingCommand { get; set; }

        private string _dentist = string.Empty;
        public string dentist
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

        public string _appointmentDate = string.Empty;
        public string AppointmentDate
        {
            get { return _appointmentDate; }
            set { SetProperty(ref _appointmentDate, value); }
        }

        public int _grade = 0;
        public int Grade
        {
            get { return _grade; }
            set { SetProperty(ref _grade, value); }
        }

        public string _comment = string.Empty;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }

        DateTime _date = DateTime.Now;
        public DateTime RatingDate
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public Appointment Appointment { get; set; }
        public Dentist Dentist { get; set; }
        public Treatment Treatment { get; set; }

        public async Task Init()
        {
            var list = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username });
            var client = list[0];

            dentist = Appointment.Dentist.FirstName + " " + Appointment.Dentist.LastName;
            TreatmentName = Appointment.Treatment.Name;
            AppointmentDate = Appointment.StartDate.ToLongDateString();
        }

        async Task AddRating()
        {
            if (Grade <= 0 || Grade > 10)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You have to add rating in range 1 - 10!", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Comment))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Comment field is required", "OK");
                return;
            }

            try
            {
                bool answer = await Application.Current.MainPage.DisplayAlert("Alert", "Would you like to add rating?", "Yes", "No");
                if (answer)
                {
                    RatingInsertRequest request = new RatingInsertRequest
                    {
                        UserID = Appointment.UserID,
                        DentistID = Appointment.DentistID,
                        DentistRating = Grade,
                        Comment = Comment,
                        RatingDate = RatingDate
                    };
                    await _ratingService.Insert<Rating>(request);
                    await Application.Current.MainPage.DisplayAlert("Success", "You have sucessfully added rating for a dentist!", "OK");

                    var appointment = await _appointmentService.GetById<Appointment>(Appointment.AppointmentID);
                    AppointmentInsertRequest update_request = new AppointmentInsertRequest
                    {
                        UserID = Appointment.UserID,
                        DentistID = Appointment.DentistID,
                        TreatmentID = Appointment.TreatmentID,
                        StartDate = Appointment.StartDate,
                        EndDate = Appointment.EndDate,
                        RatingStatus = true
                    };
                    await _appointmentService.Update<Appointment>(Appointment.AppointmentID, update_request);
                    Application.Current.MainPage = new MainPage();
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}
