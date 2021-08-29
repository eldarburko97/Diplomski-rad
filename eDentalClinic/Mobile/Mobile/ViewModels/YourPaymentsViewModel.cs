using eDentalClinic.Model;
using eDentalClinic.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
   public class YourPaymentsViewModel : BaseViewModel
    {
        private readonly APIService _paymentService = new APIService("Payments");
        private readonly APIService _userService = new APIService("Users");

        public ObservableCollection<Payment> PaymentsList { get; set; } = new ObservableCollection<Payment>();

        decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        public async Task Init()
        {
            if (PaymentsList.Count > 0)
            {
                PaymentsList.Clear();
                Total = 0;
            }

            var clients = await _userService.GetAll<List<User>>(new UserSearchRequest { Username = APIService.Username});
            var client = clients[0];

            var payments = await _paymentService.GetAll<List<Payment>>(new PaymentSearchRequest { UserID = client.UserID});
            foreach (var payment in payments)
            {
                PaymentsList.Add(payment);
                Total += payment.Amount;
            }
        }
    }
}
