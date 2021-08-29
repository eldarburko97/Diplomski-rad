using eDentalClinic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDentalClinic.WinUI.Notifications
{
    public partial class frmNotificationDetails : Form
    {
        private readonly APIService _notificationService = new APIService("Notifications");
        private int? _id = null;
        public frmNotificationDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmNotificationDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var notification = await _notificationService.GetById<Notification>(_id);
                txtTitle.Text = notification.Title;              
                txtNotificationDate.Text = notification.NotificationDate.ToString("MM/dd/yyyy");
                txtText.Text = notification.Text;               
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
