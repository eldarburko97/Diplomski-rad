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
    public class BookingAppointmentViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("Users");
        private readonly APIService _dentistService = new APIService("Dentists");
        private readonly APIService _appointmentService = new APIService("Appointments");
        private readonly APIService _ratingService = new APIService("Ratings");
        private readonly APIService _recommendationService = new APIService("Recommendations");
        public BookingAppointmentViewModel()
        {
            BookingCommand = new Command(async () => await BookAnAppointment());
        }

        public ICommand BookingCommand { get; set; }

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

        DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        DateTime _fullStartDate = DateTime.Now;
        public DateTime FullStartDate
        {
            get { return _fullStartDate; }
            set { SetProperty(ref _fullStartDate, value); }
        }

        DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        string _treatmentName = string.Empty;
        public string TreatmentName
        {
            get { return _treatmentName; }
            set { SetProperty(ref _treatmentName, value); }
        }

        string _dentist = string.Empty;  //First name + last name
        public string Dentist
        {
            get { return _dentist; }
            set { SetProperty(ref _dentist, value); }
        }

        private string _rating = string.Empty;
        public string AverageRating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        
        public DentistTreatmentDTO DentistTreatment { get; set; }

        public ObservableCollection<Dentist> RecommendedDentistList { get; set; } = new ObservableCollection<Dentist>();

        public async Task Init()
        {
            var list = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username});
            var client = list[0];
            var dentist = await _dentistService.GetById<Dentist>(DentistTreatment.DentistID);

            var ratings = await _ratingService.GetAll<List<Rating>>(null);
           
            FirstName = client.FirstName;
            LastName = client.LastName;
            Phone = client.Phone;
            Email = client.Email;
            TreatmentName = DentistTreatment.Name;
            Dentist = dentist.FirstName + " " + dentist.LastName;

            if(RecommendedDentistList.Count > 0)
            {
                RecommendedDentistList.Clear();
            }

            var result = await _recommendationService.GetAll<List<Dentist>>(new RecommendationSearchRequest { DentistID = dentist.DentistID });
            foreach (var item in result)
            {
                RecommendedDentistList.Add(item);
            }

            float averageRating = 0;
            int i = 0;
            foreach (var item in ratings)
            {
                if(dentist.DentistID == item.DentistID)
                {
                    averageRating += item.DentistRating;
                    i++;
                }
            }
            if (averageRating == 0)
            {
                AverageRating = "The dentist has no ratings yet";
                return;
            }
            AverageRating = Math.Round((decimal)averageRating / i,1).ToString();        
        }

        async Task BookAnAppointment()
        {
            try
            {
                if (Time.Hours < 8 || Time.Hours > 16)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Business hours is 8:00 AM - 17:00 PM", "OK");
                    return;
                }

                var list = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username});
                var client = list[0];

                var appointments = await _appointmentService.GetAll<List<Appointment>>(new AppointmentSearchRequest { UserID = client.UserID });
                foreach (var appointment in appointments)
                {
                    if(appointment.StartDate.Date == StartDate.Date)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "You can book only one appointment per day !", "OK");
                        return;
                    }
                }
                              
                var hours = Time.Hours;
                var minutes = Time.Minutes;
                
                FullStartDate = StartDate.Date.Add(new TimeSpan(hours, minutes, 0));
                
                AppointmentInsertRequest request = new AppointmentInsertRequest
                {
                    UserID = client.UserID,
                    DentistID = DentistTreatment.DentistID,
                    TreatmentID = DentistTreatment.TreatmentID,
                    StartDate = FullStartDate,
                    EndDate = FullStartDate.AddHours(DentistTreatment.TimeRequired),
                    RatingStatus = false
                    
                };
                
                bool answer = await Application.Current.MainPage.DisplayAlert("Alert", "Would you like to add payment?", "Yes", "No");
                if (answer)
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new PaymentPage(new DentistTreatmentAppointmentDTO {
                        UserID = client.UserID,
                        DentistID = DentistTreatment.DentistID,
                        TreatmentID = DentistTreatment.TreatmentID,
                        StartDate = FullStartDate,
                        EndDate = EndDate,
                        TimeRequired = DentistTreatment.TimeRequired
                    }));
                }
                else
                {
                    var result = await _appointmentService.Insert<Appointment>(request);

                    if (result == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Appointment already booked! Please book another appointment", "OK");
                        return;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Success", "You have successfully booked an appointment!", "OK");
                        Application.Current.MainPage = new MainPage();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
