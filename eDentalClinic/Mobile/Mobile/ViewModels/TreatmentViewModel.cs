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
   public class TreatmentViewModel : BaseViewModel
    {
        private readonly APIService _branchTreatmentService = new APIService("BranchTreatments");
        private readonly APIService _treatmentService = new APIService("Treatments");
        public TreatmentViewModel()
        {
            SearchTreatment = new Command(async () => await Load());
        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchTreatment { get; set; }

        string _treatmentName = string.Empty;
        public string TreatmentName
        {
            get { return _treatmentName; }
            set { SetProperty(ref _treatmentName, value); }
        }

        public Dentist dentist { get; set; } = null;

        public ObservableCollection<Treatment> TreatmentList { get; set; } = new ObservableCollection<Treatment>();

        public async Task Init()
        {
            if(TreatmentList.Count > 0)
            {
                TreatmentList.Clear();
            }
            BranchTreatmentSearchRequest request = new BranchTreatmentSearchRequest
            {
                BranchID = dentist.BranchID
            };

            var list = await _branchTreatmentService.GetAll<List<BranchTreatment>>(request);

            foreach (var item in list)
            {
                var treatment = await _treatmentService.GetById<Treatment>(item.TreatmentID);
                TreatmentList.Add(treatment);
            }
        }

        async Task Load()
        {
            if (TreatmentList.Count > 0)
            {
                TreatmentList.Clear();
            }

            foreach (var item in dentist.Branch.BranchTreatments)
            {
                var treatment = await _treatmentService.GetById<Treatment>(item.TreatmentID);
                if(TreatmentName == treatment.Name)
                {
                    TreatmentList.Add(treatment);
                }
            }

            if (TreatmentList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "No results found for this filter!", "OK");
            }
        }
    }
}
