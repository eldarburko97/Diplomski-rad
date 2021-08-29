using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
   public class HomeViewModel : BaseViewModel
    {
        private readonly APIService _notificationService = new APIService("Notifications");
        private readonly APIService _clinicService = new APIService("DentalClinic");

        public ObservableCollection<Notification> NotificationList { get; set; } = new ObservableCollection<Notification>();
       

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string address = string.Empty;
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        string phone = string.Empty;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public async Task Init()
        {
            var DentalClinic = await _clinicService.GetById<DentalClinic>(1);
            Name = DentalClinic.Name;
            Address = DentalClinic.Address;
            Phone = DentalClinic.Phone;
            Email = DentalClinic.Email;

            if (NotificationList.Count > 0)
            {
                NotificationList.Clear();
            }
            var list = await _notificationService.GetAll<List<Notification>>(null);

            foreach (var notification in list)
            {
                NotificationList.Add(notification);
            }
        }
    }
}
