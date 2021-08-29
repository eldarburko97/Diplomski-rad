using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
   public class DentistViewModel : BaseViewModel
    {
        private readonly APIService _dentistService = new APIService("Dentists");
        public DentistViewModel()
        {
            SearchDentist = new Command(async () => await Load());
        }

        public ICommand InitCommand { get; set; }
        public ICommand SearchDentist { get; set; }

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

        public ObservableCollection<Dentist> DentistList { get; set; } = new ObservableCollection<Dentist>();

        public async Task Init()
        {
            var list = await _dentistService.GetAll<List<Dentist>>(null);
            DentistList.Clear();
            foreach (var dentist in list)
            {
                DentistList.Add(dentist);
            }
        }

        async Task Load()
        {
            DentistSearchRequest request = new DentistSearchRequest
            {
                FirstName = FirstName,
                LastName = LastName
            };

            var list = await _dentistService.GetAll<List<Dentist>>(request);

            if(DentistList.Count > 0)
            {
                DentistList.Clear();
            }

            foreach (var item in list)
            {
                DentistList.Add(item);
            }

            if(DentistList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "No results found for this filter!", "OK");
            }
        }
    }
}
